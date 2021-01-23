     public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ButtonEx b1 = new ButtonEx();
            b1.OnCustomClickEvent += new ButtonEx.OnCustomClickEventHandler(b1_OnCustomClickEvent);
        }
        void  b1_OnCustomClickEvent(object sender, ButtonEx.CustomEventArgs eventArgs)
        {
 	        string p1 = eventArgs.CustomProperty1;
            string p2 = eventArgs.CustomProperty2;
        }
    }
    public class ButtonEx : Button
    {
        public class CustomEventArgs : EventArgs
        {
            public String CustomProperty1;
            public String CustomProperty2;
        }
        protected override void  OnClick(EventArgs e)
        {
 	        base.OnClick(e);
            if(OnCustomClickEvent != null)
            {
                OnCustomClickEvent(this, new CustomEventArgs());
            }
        }
        public event OnCustomClickEventHandler OnCustomClickEvent;
        public delegate void OnCustomClickEventHandler(object sender , CustomEventArgs eventArgs);
    }
