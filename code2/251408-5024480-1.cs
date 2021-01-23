    public class FormA
    {
        private void button1_Click(object sender, EventArgs e)
        {
            formB.Button1WasClicked();
        }
            
        private void button2_Click(object sender, EventArgs e)
        {
            formB.Button2WasClicked();
        }
    }
    
    public class FormB
    {
        public void Button1WasClicked()
        {
            label2.Visible = false;
            label1.Visible = true;
            label1.Text = "Button 1 was clicked!";
        }
    
        public void Button2WasClicked()
        {
            label1.Visible = false;
            label2.Visible = true;
            label2.Text = "Button 2 was clicked!";
        }
    }
