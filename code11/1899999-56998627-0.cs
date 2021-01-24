    public class MuLawResamplerProvider : IWaveProvider
    {
        public WaveFormat WaveFormat => WaveFormat.CreateMuLawFormat(8000, 1);
        private BufferedWaveProvider waveBuffer;
        private IWaveProvider ieeeToPcm;
        private byte[] sourceBuffer;
        /// <summary>
        /// Converts from 32-bit Ieee Floating-point format to MuLaw 8khz 8-bit 1 channel.
        /// Used for WasapiCapture and WasapiLoopbackCapture.
        /// </summary>
        /// <param name="audio">The raw audio stream.</param>
        /// <param name="inputFormat">The input format.</param>
        public MuLawResamplerProvider(byte[] stream, WaveFormat inputFormat)
        {
            // Root buffer provider.
            waveBuffer = new BufferedWaveProvider(inputFormat);
            waveBuffer.DiscardOnBufferOverflow = false;
            waveBuffer.ReadFully = false;
            waveBuffer.AddSamples(stream, 0, stream.Length);
            var sampleStream = new WaveToSampleProvider(waveBuffer);
            // Stereo to mono filter.
            var monoStream = new StereoToMonoSampleProvider(sampleStream)
            {
                LeftVolume = 2.0f,
                RightVolume = 2.0f
            };
            // Downsample to 8000 filter.
            var resamplingProvider = new WdlResamplingSampleProvider(monoStream, 8000);
            // Convert to 16-bit in order to use ACM or MuLaw tools.
            ieeeToPcm = new SampleToWaveProvider16(resamplingProvider);
            sourceBuffer = new byte[ieeeToPcm.WaveFormat.AverageBytesPerSecond];
        }
        /// <summary>
        /// Reset the buffer to the starting position with a new stream.
        /// </summary>
        /// <param name="stream">New stream to initialize.</param>
        public void Reset(byte[] stream)
        {
            waveBuffer.ClearBuffer();
            waveBuffer.AddSamples(stream, 0, stream.Length);
        }
        /// <summary>
        /// Converts the 16-bit ACM stream to 8-bit MuLaw on read.
        /// </summary>
        /// <param name="destinationBuffer">The destination buffer to output into.</param>
        /// <param name="offset">The offset to store at.</param>
        /// <param name="readingCount">The requested size to read.</param>
        /// <returns></returns>
        public int Read(byte[] destinationBuffer, int offset, int readingCount)
        {
            // Source buffer has twice as many items as the output array.
            var sizeOfPcmBuffer = readingCount * 2;
            sourceBuffer = BufferHelpers.Ensure(sourceBuffer, sizeOfPcmBuffer);
            var sourceBytesRead = ieeeToPcm.Read(sourceBuffer, 0, sizeOfPcmBuffer);
            var samplesRead = sourceBytesRead / 2;
            var outIndex = 0;
            for (var n = 0; n < sizeOfPcmBuffer; n += 2)
            {
                destinationBuffer[outIndex++] = MuLawEncoder.LinearToMuLawSample(BitConverter.ToInt16(sourceBuffer, offset + n));
            }
            return samplesRead;
        }
    }
