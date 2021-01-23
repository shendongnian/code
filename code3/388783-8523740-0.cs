        public static unsafe byte[] GetBytes(Position[] positions)
        {
            byte[] result = new byte[positions.Length * Marshal.SizeOf(typeof(Position))];
            fixed (Position* ptr = &positions[0])
            {
                Marshal.Copy((IntPtr)ptr, result, 0, result.Length);
            }
            return result;
        }
