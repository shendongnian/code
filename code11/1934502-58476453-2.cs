public partial class Form1 : Form
{
    
    private List<string> messages;
    private string RandomString()
    {
        Random random = new Random();
        return messages[random.Next(messages.Count)];
    }
//To use it just do:
//(if it is a button it should have a method that it triggers on use)
    private void HEB() 
    {
        //same for HEC, but other strings (test 3 and 4)
        messages = new List<string>(){"test 1", "test 2"}; 
    }
    private void TheButton()
    {
        textBox1.text = RandomString();
    }
}
This should work, but don't be afraid to ask for more clarification :)
EDIT: updated code that works (just add the variables and replace the code within your current buttons with the code inside mine).
namespace Test_btns
{
    public partial class Form1 : Form
    {
        private List<string> messages;
        Random random = new Random();
        private string RandomString()
        {
            return messages[random.Next(messages.Count)];
        }
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            messages = new List<string>() { "test 1", "test 2" };
        }
        private void button2_Click(object sender, EventArgs e)
        {
            messages = new List<string>() { "test 3", "test 4" };
        }
        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = RandomString();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //not really needed for this, but the method exists.
        }
    }
}
