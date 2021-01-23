    public partial class TestService : ServiceBase
    {
        public TestService()
        {
            InitializeComponent();
        }
        protected override void OnStart(string[] args) { }
        
        protected override void OnStop() { }
        
        protected override void OnCustomCommand(int command)
        {
            base.OnCustomCommand(command);
            switch (command)
            {
                case 129:
                    //
                    break;
                case 131:
                    //
                    break;
                case 132:
                    //
                    break;
            }
        }
    }
