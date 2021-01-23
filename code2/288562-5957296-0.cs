    public class Public
    {   
        public bool CheckNumber {get;set;}
    
        public string MyFunction(int val)
        {
            if(CheckNumber)
            {
                //do that thing
            }
    
            return ...
        }
    }
    public partial class Form1 : Form
    {
        Public myinstance = new Public();
        public Form1()
        {
            InitializeComponent();
        }
        private void CheckBoxChanged(object sender, EventArgs e)
        {
             myinstance.CheckNumber = chk_num.checked;
        }
    }    
