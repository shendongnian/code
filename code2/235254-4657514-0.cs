    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }
        protected override void OnStart(string[] args)
        {
            string test = this.ServiceName;
        }
        protected override void OnStop()
        {
        }
    }
