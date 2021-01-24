    TEST[] obj = new Test[10];
    int index = 0;
    private void Button1_Click(object sender, EventArgs e)
    {
       if(index < 10)  //To avoid ArrayIndexOutOfBound error
       {
          obj[index++] = new TEST();
          obj[index++].Name = textBox1.Text;
       }
    
    }
    private void Button2_Click(object sender, EventArgs e)
    {
        MessageBox.Show(obj[0].Name);
    }
    public class TEST
    {
       public string Name { get; set; }
    }
