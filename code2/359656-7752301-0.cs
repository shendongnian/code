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
        static void Main(string[] args)
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
            }
            sw4.Stop();
            if (!channel1.SequenceEqual(channel1b) || !channel1.SequenceEqual(channel1c) || !channel1.SequenceEqual(channel1d))
            {
                throw new Exception();
            }
            if (!channel2.SequenceEqual(channel2b) || !channel2.SequenceEqual(channel2c) || !channel2.SequenceEqual(channel2d))
            {
                throw new Exception();
            }
            Console.WriteLine(sw1.ElapsedMilliseconds);
            Console.WriteLine(sw2.ElapsedMilliseconds);
            Console.WriteLine(sw3.ElapsedMilliseconds);
            Console.WriteLine(sw4.ElapsedMilliseconds);
            Console.ReadKey();
            return;
        }
    }
