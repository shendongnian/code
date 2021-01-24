        [Test]
        public void MyTest()
        {
            using (NLog.NestedDiagnosticsLogicalContext.Push(System.Reflection.MethodBase.GetCurrentMethod().ToString()))
            {
                 // Testing within "${ndlc}"
            }
        }
