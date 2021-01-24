    public partial class Example : Form
    {
        private List<string> myList = new List<string>();
    
        private void Btn1_Click(object sender, EventArgs e)
        {
             var e2 = new Example2();
             e2.SetMainForm(this);
             e2.Show();
        }
        public void AddItem(string item)
        {
             myList.Add(item);
        }
    
        private void Example_Activated(object sender, EventArgs e)
        {
            if (myList.Count == 0)
            {
                //...
            }
            else
            {
                //...
            }
        }
    }
<!---->
    
    public partial class Example2 : Form
    {
        private Example ex;
    
        private void Btn2_Click(object sender, EventArgs e)
        {
            ex.AddItem("something");
            Close();
        }
    
        public void SetMainForm(Example e1)
        {
             ex = e1;
        }
    }
