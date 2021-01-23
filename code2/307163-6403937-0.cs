    [Export]
    public class MyViewModel : NotificationObject
    {
        public MyViewModel()
        {
            DoWorkCommand = new DelegateCommand(DoWork);
        }
    
        public void Initialize(Foo foo)
        {
            MyFoo = foo;
        }
    
        [Import]
        private IBarService MyBarService { get; set; }
    
        public Foo MyFoo { get; private set; }
    
        public DelegateCommand DoWorkCommand { get; set; }
    
        public void DoWork()
        {
            MyBarService.DoSomething(MyFoo);
        }
    }
