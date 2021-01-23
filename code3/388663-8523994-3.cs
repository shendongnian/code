            double d = 1.9;
            byte b = 1;
            sbyte sb = 1;
            float f = 2.0f;
            short s = 1;
            int i = -3;
            UInt16 ui = 44;
            ulong ul = ulong.MaxValue;
            bool? dd = IsInteger<double>(d); // false
            bool? dt = IsInteger<DateTime>(DateTime.Now); // null
            bool? db = IsInteger<byte>(b); // true
            bool? dsb = IsInteger<sbyte>(sb); // true
            bool? df = IsInteger<float>(f); // true
            bool? ds = IsInteger<short>(s); // true
            bool? di = IsInteger<int>(i); // true
            bool? dui = IsInteger<UInt16>(ui); // true
            bool? dul = IsInteger<ulong>(ul); // true
            int converted = GetInt32<double>(d); // coverted==2
