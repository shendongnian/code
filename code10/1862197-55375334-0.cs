            public enum Test
            {
                One,
                Two,
                Three,
                Four
            }
            static void Main(string[] args)
            {
                string[] names = Enum.GetNames(typeof(Test)).ToArray();
                foreach (var name in names)
                {
                    int value = (int)Enum.Parse(typeof(Test),name);
                }
            }
