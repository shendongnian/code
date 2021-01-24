    public class Something
    {
        public bool SomeFlag { get; set; }
    }
    internal class Program
    {
        private static void Main()
        {
            var somethings = new[] {new Something(), new Something()};
            var flags = new List<Action<bool>>();
            // create your list of 'pointers'
            foreach (var something in somethings)
            {
                flags.Add(x => something.SomeFlag = x);
            }
            // set them all to true
            foreach (var action in flags)
            {
                action(true);
            }
            // check the results
            foreach (var something in somethings)
            {
                Console.WriteLine(something.SomeFlag);
            }
            Console.WriteLine("press any key to exit...");
            Console.ReadLine();
        }
    }
