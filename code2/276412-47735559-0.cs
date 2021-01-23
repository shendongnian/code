    public partial class Form1 : Form
    {
     
        public static Form1 gui;
        public Form1()
        {
            InitializeComponent();
            gui = this;
      
        }
        public void WriteLog(string log)
        {
            this.Invoke(new Action(() => { txtbx_test1.Text += log; }));
            
        }
    }
    public class SomeAnotherClass
    {
        public void Test()
        {
            Form1.gui.WriteLog("1234");
        }
    }
