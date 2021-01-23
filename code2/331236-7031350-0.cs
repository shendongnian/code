    class DemoClass
    {
        private int[] myNumbers;
        public int[] MyNumbers
        {
            get { return myNumbers; }
            set { myNumbers = value;}
        }
        public DemoClass(int elements)
        {
            // Here, the array should get instantiated using the elements.
            MyNumbers = new int[5] { 1, 2, 3, 4, 5};
        }
    }
