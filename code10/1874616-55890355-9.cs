    static class Rogue
    {
        // This is 3rd party function so I can't make it take a cancellation token.
        public static void RogueFunction()
        {
            while (true)
            {
                Console.WriteLine("RogueFunction works");
                Thread.Sleep(1000);
            }
        }
    }
