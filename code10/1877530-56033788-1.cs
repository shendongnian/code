            // this procedure tacks the biary data stored in the jagged array called TraackData
            // and, using low level file io functions) writes it out as a .wav file called trackx.wav
        private void ConvertToWav()
        {
            int i, j, k, track, tracks;
            byte[] b;
            char[] riffchunk ={ 'R', 'I', 'F', 'F' };
            char[] wavechunk ={ 'W', 'A', 'V', 'E' };
            char[] datachunk ={ 'd', 'a', 't', 'a' };
            char[] fmtchunk ={ 'f', 'm', 't', ' ' };
            Int32 riffsize, datasize, fmtsize, extrabits;
            Int32 DI, SampleRate, ByteRate;
            uint BytesWritten;
            Int16 BlockAlign, Format, NumChannels, BitsPerSample;
            Byte[] Image;
            IntPtr FileHandle;
 
            Format = 1; // PCM
            NumChannels = 2;// Stereo
            SampleRate = 44100;// 44100 Samples per secon
            BitsPerSample = 16; // 16 bits per sample
            ByteRate = SampleRate * NumChannels * BitsPerSample / 8;
            BlockAlign = 4;
            fmtsize = 0x12;// size of the 'fmt ' chunk is 18 bytes
            // get the number of tarcks stoerd in track data
            tracks = TrackData.GetUpperBound(0);
            // setup the progressbar
            progressBar1.Maximum = tracks;
            progressBar1.Minimum = 0;
            // do all the tracks
            for (track = 0; track <= tracks; track++)
            {
                DI = 0;//IDI is an index into the Image array where the next chunk of data will be stored
                progressBar1.Value = track;
                label1.Text = "Writeing Track " + (track + 1).ToString() + ".wav";
                Application.DoEvents();
                // Create a File called trackx.wav and return a handle to it
                FileHandle=CreateFile(Application.StartupPath + "\\Track" + (track + 1).ToString() + ".wav",GENERIC_WRITE,0,IntPtr.Zero ,OPEN_ALWAYS, FILE_ATTRIBUTE_NORMAL, IntPtr.Zero );
                // Wav file format is notthe subject of this project .. .
                // suffice it to say that at minimum there is a Header which is followed by the PCM, Stereo , 44100 Hz Sample rate binary data
                // for more info on Wav format plese visit:
                //http://www.sonicspot.com/guide/wavefiles.html
 
                //Start prepareing the RIFF header
 
                // how big the the 'music' binary data
                datasize = TrackData[track].Length;
                //build the header
                riffsize = datasize;
                riffsize += 4;//RIFFSize
                riffsize += 4;//WAVE
                riffsize += 4;//fmt
                riffsize += fmtsize;
                riffsize += 4;// DATA
                riffsize += 4;//datasize
                extrabits = 0;
                // build the image
                Image = new Byte[riffsize + 8];// riffchunk + riffsize
                b = Encoding.ASCII.GetBytes(riffchunk);
                Array.Copy(b, 0, Image, DI, 4);
                DI += 4;
                b = BitConverter.GetBytes(riffsize);
                if (!BitConverter.IsLittleEndian)
                    Array.Reverse(b);
                Array.Copy(b, 0, Image, DI, 4);
                DI += 4;
                b = Encoding.ASCII.GetBytes(wavechunk);
                Array.Copy(b, 0, Image, DI, 4);
                DI += 4;
 
                b = Encoding.ASCII.GetBytes(fmtchunk);
                if (!BitConverter.IsLittleEndian)
                    Array.Reverse(b);
                Array.Copy(b, 0, Image, DI, 4);
                DI += 4;
 
                b = BitConverter.GetBytes(fmtsize);
                if (!BitConverter.IsLittleEndian)
                    Array.Reverse(b);
                Array.Copy(b, 0, Image, DI, 4);
                DI += 4;
 
                b = BitConverter.GetBytes(Format);
                if (!BitConverter.IsLittleEndian)
                    Array.Reverse(b);
                Array.Copy(b, 0, Image, DI, 2);
                DI += 2;
 
                b = BitConverter.GetBytes(NumChannels);
                if (!BitConverter.IsLittleEndian)
                    Array.Reverse(b);
                Array.Copy(b, 0, Image, DI, 2);
                DI += 2;
 
                b = BitConverter.GetBytes(SampleRate);
                if (!BitConverter.IsLittleEndian)
                    Array.Reverse(b);
                Array.Copy(b, 0, Image, DI, 4);
                DI += 4;
 
                b = BitConverter.GetBytes(ByteRate);
                if (!BitConverter.IsLittleEndian)
                    Array.Reverse(b);
                Array.Copy(b, 0, Image, DI, 4);
                DI += 4;
 
                b = BitConverter.GetBytes(BlockAlign);
                if (!BitConverter.IsLittleEndian)
                    Array.Reverse(b);
                Array.Copy(b, 0, Image, DI, 2);
                DI += 2;
 
                b = BitConverter.GetBytes(BitsPerSample);
                if (!BitConverter.IsLittleEndian)
                    Array.Reverse(b);
                Array.Copy(b, 0, Image, DI, 2);
                DI += 2;
 
                b = BitConverter.GetBytes(extrabits);
                if (!BitConverter.IsLittleEndian)
                    Array.Reverse(b);
                Array.Copy(b, 0, Image, DI, 2);
                DI += 2;
 
                b = Encoding.ASCII.GetBytes(datachunk);
                Array.Copy(b, 0, Image, DI, 4);
                DI += 4;
 
                b = BitConverter.GetBytes(datasize);
                if (!BitConverter.IsLittleEndian)
                    Array.Reverse(b);
                Array.Copy(b, 0, Image, DI, 4);
                DI += 4;
 
                // add the digital 'music' data retrieved earler
                Array.Copy(TrackData[track], 0, Image, DI, TrackData[track].Length);
                // write the binary file - trackx.wav
                i = WriteFile(FileHandle, Image, (uint)Image.Length, out BytesWritten, IntPtr.Zero);
                //if successful then
                // flush all buffers used in the low level write operation
                // then close the file
                if(i!= 0)
                {
                    //Flush the file buffers to force writing of the data.
                    i = FlushFileBuffers(FileHandle);
                    //Close the file.
                    i = CloseHandle(FileHandle);
                }
                // the wave file now exists (created by reading the CD and can be playedby most wav players
                Image = null;
                progressBar1.Value = track;
            }
        }
