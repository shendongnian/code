public partial class Form1 : Form
{
    
    private List<string> messages;
    private string RandomString()
    {
        Random random = new Random();
        return messages[random.Next(args.Count)]; //merge into one
    }
//To use it just do:
//(if it is a button it should have a method that it triggers on use)
    private void HEB() 
    {
        //same for HEC, but other strings (test 3 and 4)
        messages = new List<strings>(){"test 1", "test 2"}; 
    }
    private void TheButton()
    {
        textBox1.text = RandomString();
    }
}
This should work, but don't be afraid to ask for more clarification :)
