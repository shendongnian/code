    public class MyBaseForm : Form
    {
        protected void SomeIntitializationMethod() {...}
    }
    public class MyDerivedForm : MyBaseForm
    {
     
        public MyDerivedForm()
        {
            base.SomeInitializationMethod();
        }
    }
