    namespace WindowsFormsControlLibrary1
    {
        using System;
        using System.Runtime.InteropServices;
        using System.Windows.Forms;
    
        [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
        public interface IMyFormEvents
        {
            [DispId(1)]
            void MyEvent();
        }
    
        public delegate void MyEventEventHandler();
    
        [ComSourceInterfaces(typeof(IMyFormEvents))]
        public partial class MyForm : Form
        {
            public event MyEventEventHandler MyEvent;
    
            public MyForm()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                if (this.MyEvent != null)
                {
                    this.MyEvent();
                }
            }
        }
    }
