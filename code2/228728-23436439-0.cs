    public struct MyStruct 
    {
        private string myName;
        private int? myNumber;
        private bool? myBoolean;
        private MyRefType myType;
        public string MyName
        {
            get { return myName ?? "Default name"; }
            set { myName= value; }
        }
        public int MyNumber
        {
            get { return myNumber ?? 42; }
            set { myNumber = value; }
        }
        public bool MyBoolean
        {
            get { return myBoolean ?? true; }
            set { myBoolean = value; }
        }
        public MyRefType MyType 
        {
            get { return myType ?? new MyRefType(); }
            set { myType = value; }
        }
        //optional
        public MyStruct(string myName = "Default name", int myNumber = 42, bool myBoolean = true)
        {
            this.myType = new MyRefType();
            this.myName = myName;
            this.myNumber = myNumber;
            this.myBoolean = myBoolean;
        }
    }
----------
    [TestClass]
    public class MyStructTest
    {
        [TestMethod]
        public void TestMyStruct()
        {
            var myStruct = default(MyStruct);
            Assert.AreEqual("Default name", myStruct.MyName);
            Assert.AreEqual(42, myStruct.MyNumber);
            Assert.AreEqual(true, myStruct.MyBoolean);
            Assert.IsNotNull(myStruct.MyType);
        }
    }
