        public partial class PleaseWait : Form
        {
            public Action Worker { get; set; }
            public PleaseWait(Action worker)
            {
                InitializeComponent();
                if(worker == null)
                    throw new ArgumentNullException();
                Worker = worker;
            }
            protected override void OnLoad(EventArgs e)
            {
                 base.OnLoad(e);
                 Task.Factory.StartNew(Worker).ContinueWith(a=> 
                 {
                     this.Close();
                 }, TaskScheduler.FromCurrentSynchronizationContext());
            }
        }
