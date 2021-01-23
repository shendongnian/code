    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            checkedListBox1.Items.Add(new Subject { Name = "Hans", Code = 42 });
            checkedListBox1.Items.Add(new Subject { Name = "User", Code = 486196 });
        }
        private void button1_Click(object sender, EventArgs e) {
            var selected = new List<Subject>();
            foreach (int index in checkedListBox1.SelectedIndices) {
                selected.Add((Subject)checkedListBox1.Items[index]);
            }
            // etc...
        }
    }
