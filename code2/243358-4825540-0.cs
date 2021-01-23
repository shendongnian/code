    using System;
    using System.ComponentModel;
    using System.Threading;
    using System.Windows.Forms;
    
    class FlightUav : INotifyPropertyChanged
    {
        protected void OnNotifyChanged(string pName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(pName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private double _latitude;
        public double Latitude
        {
            get { return _latitude; }
            set { _latitude = value; OnNotifyChanged("Latitude"); }
        }
        public void Fly()
        {
            for (int i = 0; i < 100; i++)
            {
                Latitude++;
                Thread.Sleep(10);
            }
        }
        [STAThread]
        static void Main()
        {
            using (Form form = new Form())
            {
                FlightUav currentlyControlledFlightUav = new FlightUav();
    
                currentlyControlledFlightUav.PropertyChanged += delegate
                { // this should be in a *regular* method so that you can -= it when changing bindings...
                    form.Invoke((MethodInvoker)delegate
                    {
                        form.Text = currentlyControlledFlightUav.Latitude.ToString();
                    });
                };
                
    
                using (Button btn = new Button())
                {
                    btn.Text = "Fly";
                    btn.Click += delegate
                    {
                        Thread tFly = new Thread(currentlyControlledFlightUav.Fly);
                        tFly.IsBackground = true;
                        tFly.Start();
                    };
                    form.Controls.Add(btn);
                    Application.Run(form);
                }
            }
        }
    
    
    }
