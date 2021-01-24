        static void Print(IEnumerable data)
        {
            foreach (var item in data)
            {
                switch (item)
                {
                    case String str:
                        Console.WriteLine(str);
                        break;
                    default:
                        throw new NotSupportedException();
                }
            }
        }
