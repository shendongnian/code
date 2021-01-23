    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            comboBox1.TextUpdate += new EventHandler(comboBox1_TextUpdate);
            comboBox1.Items.Add(new Content { text = "one" });
            comboBox1.Items.Add(new Content { text = "two", ro = true });
            comboBox1.Items.Add(new Content { text = "three" });
        }
        private void comboBox1_TextUpdate(object sender, EventArgs e) {
            int index = comboBox1.SelectedIndex;
            if (index < 0) return;
            var content = (Content)comboBox1.Items[index];
            if (content.ro) this.BeginInvoke(new Action(() => {
                    comboBox1.SelectedIndex = index;
                    comboBox1.SelectAll();
                }));
        }
        private class Content {
            public string text;
            public bool ro;
            public override string ToString() { return text; }
        }
    }
