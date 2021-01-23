    public partial class Form2 : Form
    {
        List<String> newName;
        Form1 parent;
        public Form2(Form1 parentIn)
        {
            parent = parentIn;
            InitializeComponent();
        }
        void UpdateList()
        {
            newName = new List<String>();
            for (int i = 1; i <= numericUpDown1.Value; i++)
            {
                if (i == 1)
                    newName.Add("1 duck");
                else
                    newName.Add(i.ToString() + " ducks");
            }
        }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            UpdateList();
            parent.UpdateCombo(newName);
        }
    }
