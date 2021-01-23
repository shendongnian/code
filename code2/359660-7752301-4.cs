    class Program
    {
        [StructLayout(LayoutKind.Explicit)]
        struct UnionArray
        {
            [FieldOffset(0)]
            public byte[] Bytes;
            [FieldOffset(0)]
            public short[] Shorts;
        }
        unsafe static void Main(string[] args)
        {
            Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.High;
            byte[] rawData = new byte[10000000];
            new Random().NextBytes(rawData);
            Stopwatch sw1 = Stopwatch.StartNew();
            short[] shorts = new short[rawData.Length / 2];
            short[] channel1 = new short[rawData.Length / 4];
            short[] channel2 = new short[rawData.Length / 4];
            System.Buffer.BlockCopy(rawData, 0, shorts, 0, rawData.Length);
            for (int i = 0, j = 0; i < shorts.Length; i += 2, ++j)
            {
                channel1[j] = shorts[i];
                channel2[j] = shorts[i + 1];
            }
            sw1.Stop();
            Stopwatch sw2 = Stopwatch.StartNew();
            short[] channel1b = new short[rawData.Length / 4];
            short[] channel2b = new short[rawData.Length / 4];
            for (int i = 0, j = 0; i < rawData.Length; i += 4, ++j)
            {
                channel1b[j] = BitConverter.ToInt16(rawData, i);
                channel2b[j] = BitConverter.ToInt16(rawData, i + 2);
            }
            sw2.Stop();
            Stopwatch sw3 = Stopwatch.StartNew();
            short[] shortsc = new UnionArray { Bytes = rawData }.Shorts;
            short[] channel1c = new short[rawData.Length / 4];
            short[] channel2c = new short[rawData.Length / 4];
            for (int i = 0, j = 0; i < shorts.Length; i += 2, ++j)
            {
                channel1c[j] = shortsc[i];
                channel2c[j] = shortsc[i + 1];
            }
            sw3.Stop();
            Stopwatch sw4 = Stopwatch.StartNew();
            short[] channel1d = new short[rawData.Length / 4];
            short[] channel2d = new short[rawData.Length / 4];
            for (int i = 0, j = 0; i < rawData.Length; i += 4, ++j)
            {
                channel1d[j] = (short)((short)(rawData[i + 1]) << 8 | (short)rawData[i]);
                channel2d[j] = (short)((short)(rawData[i + 3]) << 8 | (short)rawData[i + 2]);
                //Equivalent warning-less version
                //channel1d[j] = (short)(((ushort)rawData[i + 1]) << 8 | (ushort)rawData[i]);
                //channel2d[j] = (short)(((ushort)rawData[i + 3]) << 8 | (ushort)rawData[i + 2]);
            }
            sw4.Stop();
            Stopwatch sw5 = Stopwatch.StartNew();
            short[] channel1e = new short[rawData.Length / 4];
            short[] channel2e = new short[rawData.Length / 4];
            fixed (byte* pRawData = rawData)
            fixed (short* pChannel1 = channel1e)
            fixed (short* pChannel2 = channel2e)
            {
                byte* pRawData2 = pRawData;
                short* pChannel1b = pChannel1;
                short* pChannel2b = pChannel2;
                for (int i = 0; i < rawData.Length; i += 4)
                {
                    (*(pChannel1b++)) = *((short*)pRawData2);
                    pRawData2 += sizeof(short);
                    (*(pChannel2b++)) = *((short*)pRawData2);
                    pRawData2 += sizeof(short);
                }
            }
            sw5.Stop();
            Stopwatch sw6 = Stopwatch.StartNew();
            short[] shortse = new short[rawData.Length / 2];
            short[] channel1f = new short[rawData.Length / 4];
            short[] channel2f = new short[rawData.Length / 4];
            System.Buffer.BlockCopy(rawData, 0, shortse, 0, rawData.Length);
            System.Threading.Tasks.Parallel.For(0, shortse.Length / 2, (i) =>
            {
                channel1f[i] = shortse[i * 2];
                channel2f[i] = shortse[i * 2 + 1];
            });
            sw6.Stop();
            if (!channel1.SequenceEqual(channel1b) || !channel1.SequenceEqual(channel1c) || !channel1.SequenceEqual(channel1d) || !channel1.SequenceEqual(channel1e) || !channel1.SequenceEqual(channel1f))
            {
                throw new Exception();
            }
            if (!channel2.SequenceEqual(channel2b) || !channel2.SequenceEqual(channel2c) || !channel2.SequenceEqual(channel2d) || !channel2.SequenceEqual(channel2e) || !channel2.SequenceEqual(channel2f))
            {
                throw new Exception();
            }
            Console.WriteLine("Original: {0}ms", sw1.ElapsedMilliseconds);
            Console.WriteLine("BitConverter: {0}ms", sw2.ElapsedMilliseconds);
            Console.WriteLine("Super-unsafe struct: {0}ms", sw3.ElapsedMilliseconds);
            Console.WriteLine("PVitt shifts: {0}ms", sw4.ElapsedMilliseconds);
            Console.WriteLine("unsafe VirtualBlackFox: {0}ms", sw5.ElapsedMilliseconds);
            Console.WriteLine("TPL: {0}ms", sw6.ElapsedMilliseconds);
            Console.ReadKey();
            return;
        }
    }
