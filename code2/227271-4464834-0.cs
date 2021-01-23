    public class CustomControl
    {
        private Form1 _form;
    
        public CustomControl(Form1 form)
        {
            _form = form;
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
           _form.ABC = "HI";
        }
    }
