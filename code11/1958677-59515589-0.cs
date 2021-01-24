    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void checkedListBox1_MouseClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show("Selected Index Number :" + checkedListBox1.SelectedIndex + "\n" + "Selected İndex value :" + checkedListBox1.SelectedItem.ToString());
        }
    }
