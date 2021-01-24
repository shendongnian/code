        public MyEnum GetProduct(string name)
        {
            return (MyEnum)Enum.Parse(typeof(MyEnum), name);
        }
        public MyEnum GetProduct(int number)
        {
            return (MyEnum)number;
        }
        private int lookupIndex(int number)
        {
            Array values = Enum.GetValues(typeof(MyEnum));
            int[] intArray = (int[])values;
            return Array.FindIndex(intArray, x => x == number);
        }
