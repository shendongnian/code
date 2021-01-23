        public static string t2or64()
            {
                bool os = System.Environment.Is64BitOperatingSystem;
                int x = 0;
                if (os == true)
                {
                    x = 64;
                }
                else
                {
                    x = 32;
                }
                t2s4 = Convert.ToString(x);
                return t2s4;
            }
