        public List<int> arrayList = new List<int>();
        private void test()
        {
            arrayList.Add(5);
            object[] parameters = { 5 };
            var your_arraylist= this.GetType().GetField("arrayList").GetType();
            var your_arraylist_method = your_arraylist.GetMethod("Contains");
        }
