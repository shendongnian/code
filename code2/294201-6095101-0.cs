    public partial class Form1 : Form
    {
        private SynchronizationContext _synchronizationContext;
        public Form1()
        {
            InitializeComponent();
            //Client must be careful to create sync context somehwere they are sure to be on main thread
            _synchronizationContext = AsyncOperationManager.SynchronizationContext;
        }
        //Callback method implementation - must be of this form
        public void ReceiveThreadData(object threadData)
        {
            // This callback now exeutes on the main thread.
            // Can use directly in UI without error
            this.listBoxMain.Items.Add((string)threadData);
        }
        private void DoSomeThreadWork()
        {
            // Thread needs callback and sync context so it must be wrapped in a class.
            SendOrPostCallback callback = new SendOrPostCallback(ReceiveThreadData);
            SomeThreadTask task = new SomeThreadTask(_synchronizationContext, callback);
            Thread thread = new Thread(task.ExecuteThreadTask);
            thread.Start();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DoSomeThreadWork();
        }
    }
