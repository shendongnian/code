    void Foo(params object[] args)
        {
            List<string> argStrings = new List<string>();
            
            foreach (object arg in args)
            {
                if (args.GetType().Name == typeof(String).Name)
                {
                    argStrings.Add((string)arg);
                }
                else if (args.GetType().Name == typeof(DateTime).Name)
                {
                    DateTime dateArg = (DateTime)arg;
                    argStrings.Add(dateArg.ToShortDateString());
                }
                else
                {
                    argStrings.Add(arg.ToString());
                }
            }
            
            Bar(string.Format("Some {0} text {1} here {2}", argStrings.ToArray()));
        }
