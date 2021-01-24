        public static async Task Record(CancellationToken token)
        {
            var filename = Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "/wav.pcm";
            System.IO.Stream outputStream = System.IO.File.Open(filename, FileMode.Create);
            BinaryWriter bWriter = new BinaryWriter(outputStream);
            var audioBuffer = new byte[8000];
            var audRecorder = new AudioRecord(AudioSource.Mic, 8000, ChannelIn.Mono, Encoding.Pcm16bit, audioBuffer.Length);
            while(audRecorder.State != State.Initialized) { }
            audRecorder.StartRecording();
            while (!token.IsCancellationRequested)
            {
                try
                {
                    var audioData = await audRecorder.ReadAsync(audioBuffer, 0, audioBuffer.Length);
                    bWriter.Write(audioBuffer);
                    IncrementProgressBar(1);
                }
                catch (Exception ex)
                {
                    System.Console.Out.WriteLine("INFO: " + ex.Message);
                    break;
                }
            }
            outputStream.Close();
            bWriter.Close();
            audRecorder.Stop();
            audRecorder.Release();
            fSave = true;
        }
        public static async Task Play(CancellationToken token)
        {
            var filename = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "/wav.pcm";
            var audBuffer = await System.IO.File.ReadAllBytesAsync(filename, token);
            var bufferSizeInBytes = audBuffer.Length / 2;
            AudioTrack audioTrack;
            if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.Lollipop)
            {
                AudioAttributes attributes = new AudioAttributes.Builder().SetLegacyStreamType(Android.Media.Stream.Music)
                                                                        .Build();
                AudioFormat format = new AudioFormat.Builder().SetChannelMask(ChannelOut.Mono)
                                                                .SetEncoding(Encoding.Pcm16bit)
                                                                .SetSampleRate(8000)
                                                                .Build();
                audioTrack = new AudioTrack(attributes, format, bufferSizeInBytes, AudioTrackMode.Stream, 1);
            }
            else
            {
                audioTrack = new AudioTrack(Android.Media.Stream.Music, 8000, ChannelOut.Mono,
                                            Encoding.Pcm16bit, bufferSizeInBytes, AudioTrackMode.Stream);
            }
            audioTrack.Play();
            await audioTrack.WriteAsync(audBuffer, 0, bufferSizeInBytes*2);
            try
            {
                await Task.Delay(((bufferSizeInBytes/8000)-1)*1000, token);
            }
            catch (OperationCanceledException) { }
            audioTrack.Stop();
            audioTrack.Release();
        }      
        public static async Task SaveAsAmr()
        {
            var encoder = MediaCodec.CreateEncoderByType(MediaFormat.MimetypeAudioAmrNb);
            MediaFormat format = new MediaFormat();
            format.SetString(MediaFormat.KeyMime, MediaFormat.MimetypeAudioAmrNb);
            format.SetInteger(MediaFormat.KeySampleRate, 8000);
            format.SetInteger(MediaFormat.KeyChannelCount, 1);
            format.SetInteger(MediaFormat.KeyBitRate, 7936);
            encoder.Configure(format, null, null, MediaCodecConfigFlags.Encode);
            try
            {
                Java.IO.File pcmFile = new Java.IO.File(Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "/wav.pcm");
                FileInputStream fis = new FileInputStream(pcmFile);
                Java.IO.File armFIle = new Java.IO.File(Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "/wav.amr");
                FileOutputStream fos = new FileOutputStream(armFIle);
                fos.Write(System.Text.Encoding.ASCII.GetBytes("#!AMR\n"));
                encoder.Start();
                var tempBuffer = new byte[8000];
                var hasMoreData = true;
                MediaCodec.BufferInfo outBuffInfo = new MediaCodec.BufferInfo();
                double presentationTimeUs = 0;
                int totalBytesRead = 0;
                do
                {
                    int inputBufIndex = 0;
                    while (inputBufIndex != -1 && hasMoreData)
                    {
                        inputBufIndex = encoder.DequeueInputBuffer(0);
                        if (inputBufIndex >= 0)
                        {
                            Java.Nio.ByteBuffer dstBuf;
                            if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.Lollipop)
                            {
                                dstBuf = encoder.GetInputBuffer(inputBufIndex);
                            }
                            else
                            {
                                dstBuf = encoder.GetInputBuffers()[inputBufIndex];
                            }
                            dstBuf.Clear();
                            int bytesRead = await fis.ReadAsync(tempBuffer, 0, dstBuf.Limit());
                            if (bytesRead == -1)
                            { // -1 implies EOS
                                hasMoreData = false;
                                encoder.QueueInputBuffer(inputBufIndex, 0, 0, (long)presentationTimeUs, MediaCodecBufferFlags.EndOfStream);
                            }
                            else
                            {
                                totalBytesRead += bytesRead;
                                dstBuf.Put(tempBuffer, 0, bytesRead);
                                encoder.QueueInputBuffer(inputBufIndex, 0, bytesRead, (long)presentationTimeUs, 0);
                                presentationTimeUs = 1000000L * (totalBytesRead / 2) / 8000;
                            }
                        }
                    }
                    // Drain audio
                    int outputBufIndex = 0;
                    while (outputBufIndex != (int)MediaCodecInfoState.TryAgainLater)
                    {
                        outputBufIndex = encoder.DequeueOutputBuffer(outBuffInfo, 0);
                        if (outputBufIndex >= 0)
                        {
                            Java.Nio.ByteBuffer encodedData;
                            if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.Lollipop)
                            {
                                encodedData = encoder.GetOutputBuffer(outputBufIndex);
                            }
                            else
                            {
                                encodedData = encoder.GetOutputBuffers()[outputBufIndex];
                            }
                            encodedData.Position(outBuffInfo.Offset);
                            encodedData.Limit(outBuffInfo.Offset + outBuffInfo.Size);
                            byte[] outData = new byte[outBuffInfo.Size];
                            encodedData.Get(outData, 0, outBuffInfo.Size);
                            fos.Write(outData, 0, outBuffInfo.Size);
                            encoder.ReleaseOutputBuffer(outputBufIndex, false);
                        }
                    }
                } while (outBuffInfo.Flags != MediaCodecBufferFlags.EndOfStream);
                fis?.Close();
                fos?.Flush();
                fos?.Close();
            }
            catch(Exception ex)
            {
                System.Console.Out.WriteLine("INFO: " + ex.Message);
            }
        }
