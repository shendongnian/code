    public partial class Form1 : Form
        {
    
            List<String> data;
            ListView lst = new ListView();
            TextBox txt = new TextBox();
    
            public Form1()
            {
                InitializeComponent();
                data = new List<string>("Lorem ipsum dolor sit amet consectetur adipiscing elit Suspendisse vel".Split());
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                this.Controls.Add(txt);
                lst.Top = 20;
                txt.TextChanged += new EventHandler(txt_TextChanged);
                lst.View = View.List;
                this.Controls.Add(lst);
                list_items("");
            }
    
            void txt_TextChanged(object sender, EventArgs e)
            {
                list_items(txt.Text);
            }
    
            void list_items(string filter)
            {
                lst.Items.Clear();
                List<string> results = (from d in data where d.Contains(filter) select d).ToList();
                foreach (string s in results)
                {
                    lst.Items.Add(s);
                }
            }
        }
