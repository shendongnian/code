    public partial class Form1 : Form
    {
        void Form_Load()
        {
            Port_Com.NewMessage += msg=> 
            {
                // call WriteLine on UI thread
                this.BeginInvoke(new Action(()=>{
                    this.WriteLine(msg);
                }));
            }
        }
        {...}
        public void WriteLine(string message)
            {
                this.richTextBox1.AppendText(Environment.NewLine + ">" + message);
            }
    }
    public class Port_Com
    {
        public static event Action<string> NewMessage;
        private static void Main()
        {
            //I want to call the method from here
            NewMessage?.Invoke("Message to Show");
        }
    }
