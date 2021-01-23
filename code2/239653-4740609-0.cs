            byte[] bytes = {
                               0xEF, 0xBC, 0x88, 0xE3,
                               0x80, 0x80, 0xEF, 0xBE,
                               0x9F, 0x20, 0xD0, 0x94,
                               0xEF, 0xBE, 0x9F, 0xEF,
                               0xBC, 0x89, 0x0D, 0x0A,
                               0xEF, 0xBE, 0x9F
                           };
            string t = System.Text.Encoding.UTF8.GetString(bytes);
            System.Diagnostics.Trace.WriteLine(t);
