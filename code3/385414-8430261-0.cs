    using System.Drawing;
    using System.Windows.Forms;
    
    public class Form1
    {
    
        public void Form1()
        {
            InitializeComponent();
    
            // initialize the imagelist
            ImageList imageList1 = new ImageList();
            imageList1.Images.Add("key1", Image.FromFile(@"C:\path\to\file.jpg"));
            imageList1.Images.Add("key2", Image.FromFile(@"C:\path\to\file.ico"));
    
            //initialize the tab control
            TabControl tabControl1 = new TabControl();
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.ImageList = imageList1;
            tabControl1.TabPages.Add("tabKey1", "TabText1", "key1"); // icon using ImageKey
            tabControl1.TabPages.Add("tabKey2", "TabText2", 1);      // icon using ImageIndex
            this.Controls.Add(tabControl1);
        }
    }
