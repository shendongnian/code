    public class MyClass
    {
        private string _myString = null;
        private void checkBox1_CheckedChanged(object sender, System.EventArgs e)
        {
            _myString = "some value";
        }
        private void button1_Click_1(object sender, System.EventArgs e)
        {
            //you can now use _myString in this function
        }
    }
