        var s = new MutableStruct();
        var span = MemoryMarshal.CreateReadOnlySpan(ref s, 1);
        var byteSpan = MemoryMarshal.Cast<MutableStruct, byte>(span);
        Console.WriteLine(string.Join("", byteSpan.ToArray().Select(v => $"{v:X2}"))); // 00000000
        s.SetX(42);
        Console.WriteLine(string.Join("", byteSpan.ToArray().Select(v => $"{v:X2}"))); // 2A0000000
        Console.ReadKey();
        // here the used struct
        struct MutableStruct
        {
            private int _x;
            public int X => _x;
            public void SetX(int value) => _x = value;
        }
