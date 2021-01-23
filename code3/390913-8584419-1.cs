        private Dictionary<MethodBase, object[]> methodCollection = new Dictionary<MethodBase, object[]>();
        public void AddMethod(MethodBase method, params object[] arguments)
        {
            methodCollection.Add(method, arguments);
        }
        private void MyMethod(int p1, string p2, bool p3)
        {
            AddMethod(System.Reflection.MethodInfo.GetCurrentMethod(), new object[] { p1, p2, p3 });
        }
        private void MyOtherMethod()
        {
            AddMethod(System.Reflection.MethodInfo.GetCurrentMethod(), new object[] { });
        }
