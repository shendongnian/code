    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    
    namespace WavGeneratorDemo
    {
        class Program
        {
            const int INT24_MAX = 0x7f_ffff;
    
            static void Main(string[] args)
            {
                const int sampleRate = 44100;
                const int lengthInSeconds = 15 /* sec */;
                const int channels = 2;
                const double channelSamplesPerSecond = sampleRate * channels;
                var samples = new double[lengthInSeconds * sampleRate * channels];
    
                // Left is 440 Hz sine wave
                FillWithSineWave(samples, channels, channelSamplesPerSecond, 0 /* Left */, 440 /* Hz */);
                // Right is 1 kHz sine wave
                FillWithSineWave(samples, channels, channelSamplesPerSecond, 1 /* Right */, 1000 /* Hz */);
    
                WriteWavFile(samples, sampleRate, channels, "out.wav");
            }
    
            private static void WriteWavFile(double[] samples, uint sampleRate, ushort channels, string fileName)
            {
                using (var wavFile = File.OpenWrite(fileName))
                {
                    const int chunkHeaderSize = 8,
                        waveHeaderSize = 4,
                        fmtChunkSize = 16;
                    uint samplesByteLength = (uint)samples.Length * 3u;
    
                    // RIFF header
                    wavFile.WriteAscii("RIFF");
                    wavFile.WriteLittleEndianUInt32(
                        waveHeaderSize
                        + chunkHeaderSize + fmtChunkSize
                        + chunkHeaderSize + samplesByteLength);
                    wavFile.WriteAscii("WAVE");
    
                    // fmt header
                    wavFile.WriteAscii("fmt ");
                    wavFile.WriteLittleEndianUInt32(fmtChunkSize);
                    wavFile.WriteLittleEndianUInt16(1);               // AudioFormat = PCM
                    wavFile.WriteLittleEndianUInt16(channels);
                    wavFile.WriteLittleEndianUInt32(sampleRate);
                    wavFile.WriteLittleEndianUInt32(sampleRate * channels);
                    wavFile.WriteLittleEndianUInt16((ushort)(3 * channels));    // Block Align (stride)
                    wavFile.WriteLittleEndianUInt16(24);              // Bits per sample
    
                    // samples data
                    wavFile.WriteAscii("data");
                    wavFile.WriteLittleEndianUInt32(samplesByteLength);
                    for (int i = 0; i < samples.Length; i++)
                    {
                        var scaledValue = DoubleToInt24(samples[i]);
                        wavFile.WriteLittleEndianInt24(scaledValue);
                    }
                }
            }
    
            private static void FillWithSineWave(double[] samples, int channels, double channelSamplesPerSecond, int channelNo, double freq)
            {
                for (int i = channelNo; i < samples.Length; i += channels)
                {
                    var t = (i - channelNo) / channelSamplesPerSecond;
                    samples[i] = Math.Sin(t * (freq * Math.PI * 2));
                }
            }
    
            private static int DoubleToInt24(double value)
            {
                if (value < -1 || value > 1)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }
    
                return (int)(value * INT24_MAX);
            }
        }
    
        static class StreamExtensions
        {
            public static void WriteAscii(this Stream s, string str) => s.Write(Encoding.ASCII.GetBytes(str));
    
            public static void WriteLittleEndianUInt32(this Stream s, UInt32 i)
            {
                var b = new byte[4];
                b[0] = (byte)((i >> 0) & 0xff);
                b[1] = (byte)((i >> 8) & 0xff);
                b[2] = (byte)((i >> 16) & 0xff);
                b[3] = (byte)((i >> 24) & 0xff);
                s.Write(b);
            }
    
            public static void WriteLittleEndianInt24(this Stream s, Int32 i)
            {
                var b = new byte[3];
                b[0] = (byte)((i >> 0) & 0xff);
                b[1] = (byte)((i >> 8) & 0xff);
                b[2] = (byte)((i >> 16) & 0xff);
                s.Write(b);
            }
    
            public static void WriteLittleEndianUInt16(this Stream s, UInt16 i)
            {
                var b = new byte[2];
                b[0] = (byte)((i >> 0) & 0xff);
                b[1] = (byte)((i >> 8) & 0xff);
                s.Write(b);
            }
        }
    }
