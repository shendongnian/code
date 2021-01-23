    public partial class Form1 : Form
    {
        private object _obj;
    
        public Form1()
        {
            InitializeComponent();
    
            _obj = new object();
    
            _obj.RegisterGCEvent(delegate(int hashCode)
            {
                MessageBox.Show("Object with hash code " + hashCode + " recently collected");
            });
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            _obj = null;
            GC.Collect();
        }
    }
