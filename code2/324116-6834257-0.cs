    public class MyType {
       public int AsynchExecutions { get; set; }
    }
    public partial class ThreadForm : Form
    {
        private MyType type;
        public ThreadForm(MyType t)
        {
            this.type = t;
            this.type.AsynchExecutions = 1;
            InitializeComponent();
        }
    
        private void start_Button_Click(object sender, EventArgs e)
        {
            int a;
            if (int.TryParse(asynchExecution_txtbx.Text, out a))
                this.type.AsynchExecutions = a;
    
            this.Dispose();
        }
   
    }
