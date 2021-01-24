        public void Write(string path)
        {
            FileStream fs = new FileStream(path, FileMode.Create);
            using (fs)
            {
                StreamWriter sw = new StreamWriter(fs);
                using (sw)
                {
                    string VarInput = "11111111";
                    char[] characters = VarInput.ToCharArray();
                    sw.Write(characters);
                }
            }
        }
- [About doc](https://docs.microsoft.com/en-gb/dotnet/csharp/programming-guide/file-system/)
