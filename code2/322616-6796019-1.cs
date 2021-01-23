    public Form1()
        {
            InitializeComponent();
            Recipe r1 = new Recipe() { Text = "Re1" };
            Recipe r2 = new Recipe() { Text = "Re2" };
            Recipe r3 = new Recipe() { Text = "Re3" };
            listBox1.Items.Add(r1);
            listBox1.Items.Add(r2);
            listBox1.Items.Add(r3);
            
            tabControl1.TabPages.Add(new AdvancedTabPage() { Recipe = r1,Text=r1.ToString() });
            tabControl1.TabPages.Add(new AdvancedTabPage() { Recipe = r2, Text = r2.ToString() });
            tabControl1.TabPages.Add(new AdvancedTabPage() { Recipe = r3, Text = r3.ToString() });
            listBox1.SelectedIndexChanged += new EventHandler(listBox1_SelectedIndexChanged);
        }
        void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
                foreach (AdvancedTabPage ad in tabControl1.TabPages)
                {
                    if (ad.Recipe == listBox1.SelectedItem)
                    {
                        tabControl1.SelectedTab = ad;
                        break;
                    }
                }
            
        }
        public class AdvancedTabPage : System.Windows.Forms.TabPage
        {
            public Recipe Recipe{get;set;}
        }
        public class Recipe
        {
            public string Text = "";
            public override string ToString()
            {
                return Text;
            }
        }
