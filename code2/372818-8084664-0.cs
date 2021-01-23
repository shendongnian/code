    public partial class LargeTopNavMaster : MasterPage
    {
        // ...
        public string ThePropertyOfTheContainedControl
        {
            get { return MyContainedControl.TheProperty; }
                set { MyContainedControl.TheProperty = value; }
        }
        // ...
    }
