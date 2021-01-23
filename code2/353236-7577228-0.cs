    public class TestClass : Page
    {
        public void OtherMethod()
        {
            ((MasterPage) this.Master).MyMethod();
        }
    }
