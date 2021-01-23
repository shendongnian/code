        public partial class Form1 : Form
        {
            List<String> _animals = new List<String> { "cat", "carrot", "dog", "goat", "pig" };
    
            public Form1()
            {
                InitializeComponent();
    
                listBox1.Items.AddRange(_animals.ToArray());
            }
    
            private void textBox1_TextChanged(object sender, EventArgs e)
            {
                String search = textBox1.Text;
    
                if (String.IsNullOrEmpty(search))
                {
                    listBox1.Items.Clear();
                    listBox1.Items.AddRange(_animals.ToArray());
                }
    
                var items = (from a in _animals
                            where a.StartsWith(search)
                            select a).ToArray<String>();
    
                listBox1.Items.Clear();
                listBox1.Items.AddRange(items);
            } 
        }
