    public partial class Form1 : Form
    {
        CheckBox[] cbs;
        public Form1()
        {
            InitializeComponent();
            cbs = new CheckBox[] { checkBox1, checkBox2 }; //put all in here
            for (int i = 0; i < cbs.Length; i++)
            {
                cbs[i].Name = "myCheckBox" + (i + 1);
                cbs[i].CheckedChanged += new EventHandler(CheckBoxes_CheckedChanged);
            }
        }
        private void CheckBoxes_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            MessageBox.Show(cb.Name + " " + ((cb.Checked) ? " is checked" : "is not checked").ToString());
        }
        private void buttonStateAll_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            foreach (CheckBox cb in cbs)
            {
                sb.AppendLine(cb.Name + " " + ((cb.Checked) ? " is checked" : "is not checked").ToString());
            }
            MessageBox.Show(sb.ToString());
        }
    }
