        public static void DoSomthingWithObject(Object obj)
        {
            if (!obj.GetType().IsPrimitive)
            {
                Console.WriteLine("This is a class.");
                var properties = obj.GetType().GetProperties();
                foreach (var p in properties) {
                    Console.WriteLine(p);
                }
            }
            else
            {
                Console.WriteLine("This is NOT a class.");
            }
        }
