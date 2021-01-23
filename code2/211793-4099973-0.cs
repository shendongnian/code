    public class Form1
    {
        protected Textbox tbx_Log;
        public void Log(string str)
        {
            tbx_Log.Text += str + Environment.NewLine;
        }
    }
    public class Program
    {
        private void DoStuff()
        {
            Form1 myForm = new Form1();
            //Make form visible, etc...
            myForm.Log("Test Log");
        }
    }
