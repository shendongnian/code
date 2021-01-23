`
public partial class Test
    {
    public Test()
        {
            this.RemoveHandler(KeyDownEvent, new KeyEventHandler(Test_KeyDown)); 
            // im not sure if the above line is needed (or if the GC takes care of it
            // anyway) , im adding it just to be safe  
            this.AddHandler(KeyDownEvent, new KeyEventHandler(Test_KeyDown), true);
            InitializeComponent();
        }
     //....
      private void Test_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                //your logic
            }
        }
    }
`
