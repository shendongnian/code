    public partial class Form2 : Form
        {
           
    
            public string Name { get; set; }
            public bool Flag { get; set; }
    
            public Form2()
            {
                InitializeComponent();
            }
    
            public void MyCollectionAdded(object sender, StringEventArgs e)
            {
                //Some action
                Flag = true;
                label1.Text = string.Format("{0} has added {1} to its list, flag={2}", Name, e.StringAddedOrRemoved, Flag);
            }
    
            public void MyCollectionRemoved(object sender, StringEventArgs e)
            {
                //Some action
                Flag = false;
                label1.Text = string.Format("{0} has removed {1} from its list, flag={2}", Name, e.StringAddedOrRemoved, Flag);
            }
        }
