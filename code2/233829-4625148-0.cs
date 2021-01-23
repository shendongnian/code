    public Window8()
    {
        InitializeComponent();
        DataContext = this;
        var newList = new ObservableCollection<Test>();
        newList.Add(new Test { I = 1, S = "Test" });
        TestObject = new TestObj { S = "Testing object", List = newList };
        Count = TestObject.List.Count;
    }
    public class TestObj
    {
        public string S { get; set; }
        public ObservableCollection<Test> List { get; set; }
    }
