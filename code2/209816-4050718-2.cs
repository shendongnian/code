    public partial class Form1 : Form
        {
            public static MyCollection collection;
    
    
            public Form1()
            {
    
                InitializeComponent();
    
                collection = new MyCollection();
    
                Form2 form2 = new Form2();
                form2.Show();
    
                Form3 form3 = new Form3();
                form3.Show();
    
                collection.OnAdded += form2.MyCollectionAdded;
                collection.OnRemoved += form2.MyCollectionRemoved;
    
                collection.OnAdded += form3.MyCollectionAdded;
                collection.OnRemoved += form3.MyCollectionRemoved;
    
            }
    
            private void Add_Click(object sender, EventArgs e)
            {
                collection.Add("test add");
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                collection.Remove("test add");
            }
    
    
        }
