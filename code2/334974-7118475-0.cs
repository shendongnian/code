            static void Main(string[] args)
            {
                animal slyvester = new cat();
                animal lassie = new dog();
                animal silver = new horse();
    
                DoSomething(slyvester);
                DoSomething(lassie);
                DoSomething(silver);
    
                Console.ReadLine();
            }
    
            static void DoSomething(animal entity)
            {
                string INeedThisProperty = "PurrStrength";
                Type type = entity.GetType();
                PropertyInfo property = type.GetProperty(INeedThisProperty);
    
                if (property != null && property.CanRead)
                {
                    Console.WriteLine("Found: {0}", property.GetValue(entity, null));
                }
            }
