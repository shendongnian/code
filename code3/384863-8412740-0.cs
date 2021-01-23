    public static class Extensions {
    
        public static List<TestModel> Add(this List<TestModel> list, int test1, string test2)   {
            return list.Add(new TestModel { Test1 = test1, Test2 = test2 });
        }
    }
