    [DllImport("TradeEngine.dll", CharSet = CharSet.Ansi,
                CallingConvention = CallingConvention.StdCall,
                ExactSpelling = true),
            SuppressUnmanagedCodeSecurity]
            public static extern void Mafonc(StringBuilder nom);
