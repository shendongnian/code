    class Sample
    {
        string[] strings = new[]{ "123","123456", "12345"};
        public void SampleMethod()
        {
            var res = strings.AsEnumerable().OrderBy(s => s.Length, new MyComparer());
        }
        class MyComparer : IComparer<int>
        {
            public int Compare(int x, int y)
            {
                if (x == 6) return -1;
                return x - y;
            }
        }
    }
