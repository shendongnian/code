    public class MyClass {
        [Obsolete("This method should no longer be used, please use MyNewMethod() instead.", true)]
        public void MyMethod(string name, long phoneNumber, long faxNumber) { 
        }
        public void MyNewMethod(string name, long phoneNumber, long faxNumber, string email) { 
        }
    }
