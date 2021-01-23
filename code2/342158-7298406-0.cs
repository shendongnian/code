    public class Person
    {
        public static void Walk()
        {
            using(var actions = new PresonActions())
            {
                actions.Walk();
            }
        }
    }
