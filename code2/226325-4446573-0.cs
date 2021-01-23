    public partial class MainForm : Form
    {
        SynchronizationContext ctx;
        public MainForm()
        {
            ctx = SynchronizationContext.Current;
            Test t = new Test();
    
            Thread testThread = new Thread(new ThreadStart(t.HelloWorld));
            testThread.IsBackground = true;
            testThread.Start();
        }
    
        private void UpdateTextBox(string text)
        {
            ctx.Send(delegate(object state)
            {
                textBox1.AppendText(text + "\r\n");
            },null);
        }    
    }
    
    public class Test
    {
        public void HelloWorld()
        {
            MainForm.UpdateTextBox("Hello World"); 
            // How do I excute this on the main thread ???
        }
    }
