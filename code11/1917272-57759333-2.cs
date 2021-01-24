    public class Test // Class should start with capital 
    {
        private Form1 frm;
        // Have a constructor that takes a Form1
        public Test( Form1 f )
        {
            frm = f;
        }
        public void set_text(string s)
        {
           // This is bad!
           frm.textBox1.AppendText(s);
        }
    }
