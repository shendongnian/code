     class DemoClass
        {
            private int[] myNumbers;
            public int[] MyNumbers
            {
                get { return myNumbers; }
                set { myNumbers = value; }
            }
    
            public DemoClass(int[] elements)
            {
                myNumbers = elements;
                // Here, the array should get instantiated using the elements.
            }
        }
