    if (o is IEnumerable)
            {
                Console.WriteLine(string.Join("|",
                    (o as IList))[0]);
    
            }
            else
            {
                Console.WriteLine(o.ToString());
            }
