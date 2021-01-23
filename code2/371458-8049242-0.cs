        // all good here
        public MainWindow()
        {
            InitializeComponent();
        }
        // also all good here
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Thread[] threads = new Thread[3];
            for (int i = 0; i < 3; i++)
            {
                int index = i;
                threads[i] = new Thread(new ThreadStart(test));
                threads[i].SetApartmentState(ApartmentState.STA);
                threads[i].IsBackground = true;
                threads[i].Start();
            }
        }
        // here's the change
        public void test()
        {
            OutputWindow outputwindow = new OutputWindow();
            outputwindow.Show();
            // here you create another thread which will execute your work code (the one you had after the Dispatcher.run statement
            Thread workThread = new Thread(new ParameterizedThreadStart(workMethod));
            workThread.IsBackground = true;
            // start the work thread BUT transfer the reference to outputwindow
            workThread.Start(outputwindow); 
            System.Windows.Threading.Dispatcher.Run();
            // no more code here; it has been transferd to workMethod which runs in another thread
        }
        public void workMethod(object threadParam)
        {
            OutputWindow outputwindow = (OutputWindow)threadParam;
            // those are little ugly but you must go through dispatcher because you are now in a different thread than your outputwindow
            outputwindow.Dispatcher.BeginInvoke((Action)(() => { outputwindow.textBox1.Text = "writing"; }), System.Windows.Threading.DispatcherPriority.Normal);
            //some more stuff done
            //some more stuff done
            //some more stuff done
            outputwindow.Dispatcher.BeginInvoke((Action)(() => { outputwindow.textBox1.Text = "\nmore writing"; }), System.Windows.Threading.DispatcherPriority.Normal);
            //some more stuff done
            //some more stuff done
            //some more stuff done
            outputwindow.Dispatcher.BeginInvoke((Action)(() => { outputwindow.textBox1.Text = "\nmore writing"; }), System.Windows.Threading.DispatcherPriority.Normal);
            // and finally close the outputWindow
            outputwindow.Dispatcher.InvokeShutdown();
        }
