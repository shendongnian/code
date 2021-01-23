            byte[] bytes = BitConverter.GetBytes(0x08fdc941);
            if (BitConverter.IsLittleEndian)
            {
                bytes = bytes.Reverse().ToArray();
            }
            float myFloat = BitConverter.ToSingle(bytes, 0);
