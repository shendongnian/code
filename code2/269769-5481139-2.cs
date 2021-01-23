    static class GrottyHacks
    {
        internal static T Cast<T>(object target, T example)
        {
            return (T) target;
        }
    }
    
    class CheesecakeFactory
    {
        static object CreateCheesecake()
        {
            return new { Fruit="Strawberry", Topping="Chocolate" };
        }
        
        static void Main()
        {
            object weaklyTyped = CreateCheesecake();
            var stronglyTyped = GrottyHacks.Cast(weaklyTyped,
                new { Fruit="", Topping="" });
            
            Console.WriteLine("Cheesecake: {0} ({1})",
                stronglyTyped.Fruit, stronglyTyped.Topping);            
        }
    }
