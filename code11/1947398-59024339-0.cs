    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        void form1_AddTab(string name)
        {
            tabControl1.TabPages.Add(name);
        }
        private void btOpenForm2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            // Subscribe to the event
            form2.AddEvent += form1_AddTab;
            form2.ShowDialog();
        }
    }
