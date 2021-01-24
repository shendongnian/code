        public static T EnterNumber<T> ()
        {
            while (true)
            {
                Console.Write("Enter an " + typeof(T) + " number: ");
                try
                {
                    return (T) Convert.ChangeType(Console.ReadLine(), typeof(T));
                }
                catch (FormatException ex)
                {
                    Console.Write("Incorrect format" + ex.Message);
                }
            }
        }
