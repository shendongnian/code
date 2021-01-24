        [Test]
        public void Test()
        {
            var data = new[] { 0, 0, 7, 0 };
            var test1 = data.FirstOrDefault(isSeven);
            var test2 = data.Where(isSeven).FirstOrDefault();
        }
        private bool isSeven(int val)
        {
            return val == 7;
        }
