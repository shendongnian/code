    class YourClass
    {
        private static Random randomGenerator = new Random();
        public YourClass(int entriesCount)
        {
           int weight = 0;
           for (int i = 0; i < entriesCount; i++)
           {
               weight = randomGenerator.Next(10);
               this.weights[i] = weight;
           }
        }
        // .. rest of your class
