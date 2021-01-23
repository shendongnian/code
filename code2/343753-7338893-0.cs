        public void DoSort()
        {
            list.Sort(Compare); //Pass method as a Comparison<Product>
        }
        public int Compare(Product x, Product y)
        {
            return x.Name.CompareTo(y.Name);
        }
