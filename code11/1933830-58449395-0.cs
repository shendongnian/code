            [TestCaseSource(typeof(MyDataClass), "TestCases")]
            public void MyMethod_WhenCalled_ReturnsANotNullString(IMyInterface sut, string value)
        {
            //arrange
            
            //act
            string result = sut.MyMethod(value);
            //assert
            Assert.IsNotNull(result);
        }
        public class MyDataClass
        {
            public static IEnumerable TestCases
            {
                get
                {
                    yield return new TestCaseData(new MyClassA(), "hi");
                    yield return new TestCaseData(new MyClassB(), "test");
                    yield return new TestCaseData(new MyClassC(), "another");
                }
            }
        }
