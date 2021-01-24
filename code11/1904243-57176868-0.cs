    public static void DoSomthingWithObject(Object obj)
            {
                if (!obj.GetType().IsPrimitive)
                {
                    Console.WriteLine("This is a class.");
                }
                else
                {
                    Console.WriteLine("This is NOT a class.");
                }
            }
