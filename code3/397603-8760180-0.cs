    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       // the function that updates the listbox
       public void logURI(string OutputLog, string Information, string JOB)
        {
            try
            {
                listBox1.BeginUpdate();
                listBox1.Items.Add("0");
                listBox1.Items[0] = DateTime.Now.ToString() + " : " + JOB + " " + Information;
                listBox1.Items.Add("1");
                listBox1.EndUpdate();
                textBox1.Text = JOB;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
}
    public class FtpFileSystemWatcherTS : Form1
    {
         logURI( "", "Found folder modefied today (" + FileName.TrimEnd().toString(), ") ElectricaTS"); 
    }
