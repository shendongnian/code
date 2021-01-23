    class Class1 : IButtonClass
        {
    
            public Button MyButton { get; set; }
    
            public Class1()
            {
                MyButton = new Button();
                MyButton.Tag = this;        
            }
    
            public void DoSoemthing()
            {
                //Do something
            }
    
        }
    
        interface IButtonClass
        {
            void DoSoemthing();
        }
    
    public partial class Form1 : Form
        {
            Class1 c1 = new Class1();
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                c1.MyButton.Width = 100;
                c1.MyButton.Height = 100;
                c1.MyButton.Top = 0;
                c1.MyButton.Left = 0;
                this.Controls.Add(c1.MyButton);
    
                c1.MyButton.Click += new EventHandler(MyButton_Click);
            }
        void MyButton_Click(object sender, EventArgs e)
        {
            IButtonClass c = ((Button)sender).Tag as IButtonClass;
            c.DoSoemthing();
        }
    }
