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
                BindingSource bindSrc = new BindingSource();
                var list = new ThreadedBindingList<FlightUav>();
                list.Add(currentlyControlledFlightUav);
                bindSrc.DataSource = list;
    
                form.DataBindings.Clear();
                form.DataBindings.Add("Text", list, "Latitude");
    
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
    public class ThreadedBindingList<T> : BindingList<T>
    {
        private readonly SynchronizationContext ctx;
        public ThreadedBindingList()
        {
            ctx = SynchronizationContext.Current;
        }
        protected override void OnAddingNew(AddingNewEventArgs e)
        {
            SynchronizationContext ctx = SynchronizationContext.Current;
            if (ctx == null)
            {
                BaseAddingNew(e);
            }
            else
            {
                ctx.Send(delegate
                {
                    BaseAddingNew(e);
                }, null);
            }
        }
        void BaseAddingNew(AddingNewEventArgs e)
        {
            base.OnAddingNew(e);
        }
        protected override void OnListChanged(ListChangedEventArgs e)
        {
            if (ctx == null)
            {
                BaseListChanged(e);
            }
            else
            {
                ctx.Send(delegate
                {
                    BaseListChanged(e);
                }, null);
            }
        }
        void BaseListChanged(ListChangedEventArgs e)
        {
            base.OnListChanged(e);
        }
    }
    
