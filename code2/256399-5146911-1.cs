    [ParseChildren(ChildrenAsProperties = true)]
    public partial class MyControl: UserControl
    {
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public TestClass TestLabel
        {
             get;set;
        }
    }
    public class TestClass
    {
        public string Field1
        { get; set; }
        public string Field2
        { get; set; }
    }
