    class array
    {
        protected int[] arr {get; private set; }
        public array(int[] arr)
        {
            this.arr = arr;
        }
        public int Biggest()
        {
            return arr.Max();
        }
        public int Min()
        {
            return arr.Min();
        }
        public int SumArr()
        {
            return arr.Sum();
        }
    }
    class array2 : array
    {
         public array2(int [] arr):base(arr)
         {
         }
         public double Average()
         {
            return arr.Average();
         }
    }
