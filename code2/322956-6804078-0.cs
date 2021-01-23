    public class MyClass
    {
        public void MyMethod()
        {
            Form1 MyForm1 = new Form1();
            MyForm1.Show(); // Missing this line
            MyForm1.UpdateLabel("outside");
            // or use MyForm1.ShowDialog();
        }
    }
