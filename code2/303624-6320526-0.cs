     public static char[] GetConstants()
            {
                var array = Enumerable.Range((int) 'a', 26).ToList();
                array.AddRange(Enumerable.Range((int) 'A', 26));
                array.Add('_');
                return array.Select(z => (char) z).ToArray();
    
            }
