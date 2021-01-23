    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            asyncInvoke = new AsyncInvoke();
        }
        AsyncInvoke asyncInvoke;
        EventWaitHandle waitMeHandle = new EventWaitHandle(false, EventResetMode.ManualReset);
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(delegate(object state)
            {
                asyncInvoke.BeginAsync(ChangeText);
            }), null);
            ThreadPool.QueueUserWorkItem(new WaitCallback(delegate(object state)
            {
                asyncInvoke.BeginAsync(ChangeColor);
            }), null);
            label1.Content += " \r\n-------------------------\r\n";
        }
        private bool ChangeText()
        {
            Debug.WriteLine("ChangeText");         
            //do your time-consuming operation here, controls' delegated are for UI updates only
            this.button1.Dispatcher.Invoke((Action)(()=>
            {
                Thread.Sleep(2000);
                Debug.WriteLine("Button invoker");
                //update button here
                //what was bool return type for?
                label1.Dispatcher.Invoke((Action)(() =>
                {
                    label1.Content += "Loading finish!(Thread.CurrentThreadName=" + Thread.CurrentThread.ManagedThreadId.ToString() + ") ";
                    waitMeHandle.Set();
                }));
            }));
            //waitMeHandle.Set(); - here's your guilty - button delegate runs asynchrounously so you had absolutely no guarantee that it's done as your app reach this line
            return true;
        }
        private bool ChangeColor()
        {
            waitMeHandle.WaitOne();
            Debug.WriteLine("ChangeColor");
            this.button1.Dispatcher.Invoke((Action)(() =>
            {
                this.button1.Background = Brushes.Red;
                label1.Dispatcher.Invoke((Action)(() =>
                {
                    label1.Content += "Coloring finish!(Thread.CurrentThreadName=" + Thread.CurrentThread.ManagedThreadId + ") ";
                    waitMeHandle.Reset(); //you've consumed your event here so this is the place to reset it
                }));
            }));
            return true;
        }
    }
