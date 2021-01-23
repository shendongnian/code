        public static int MyPrintFormat(string format, VariableArgumentBuffer arglist)
        {
            var stream = new UnmanagedMemoryStream(arglist.Buffer, VariableArgumentBuffer.BufferLength);
            var binary = new BinaryReader(stream);
            ....
        }
