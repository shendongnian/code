     class Program
        {
            private class Effect
            {
                public string Name { get; set; }
            }
    
            static void Main(string[] args)
            {
                List<Effect> list = new List<Effect> {new Effect(), new Effect(), new Effect()};
    
                list.Select((element, index) =>
                {
                    element.Name = "Effect " + index.ToString();
                    return element;
                }).ToList();
                
    
                foreach (var effect in list)
                {
                    Console.WriteLine(effect.Name);
                }
            }
        }
