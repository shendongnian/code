    using System;
    using System.ComponentModel;
    using System.Threading;
    using System.Windows.Forms;
    class Foo
    {
        public int Value { get; set; }
        public Foo(int value) { Value = value; }
        public override string ToString() { return Value.ToString(); }
    }
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            using(var form = new Form())
            using (var lst = new ListBox())
            {
                form.Controls.Add(lst);            
                lst.Dock = DockStyle.Fill;
                form.Shown += delegate
                {
                    BindingList<Foo> data = new ThreadedBindingList<Foo>();
                    lst.DataSource = data;
                    ThreadPool.QueueUserWorkItem(delegate
                    {
                        int i = 0;
                        while (true)
                        {
                            data.Add(new Foo(i++));
                            Thread.Sleep(1000);
                        }
                    });
                };
                Application.Run(form);
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
