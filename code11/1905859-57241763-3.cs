    Test[] testArray = new Test[10];
    int index = 0;
    private void Button1_Click(object sender, EventArgs e)
    {
       if(index < 10)  //To avoid ArrayIndexOutOfBound error
       {
          testArray[index++] = new Test() { Name = textBox1.Text };
       }
    
    }
    private void Button2_Click(object sender, EventArgs e)
    {
        string firstName = testArray.Where(x => x.Name == "A");
        MessageBox.Show(firstName);
    }
    public class Test
    {
       public string Name { get; set; }
    }
