    public class Form2
    {
       ...
       public string MyProperty { get; set; }
    
       private void Form2_Load(object sender, EventArgs e)
       {
           MessageBox.Show(this.MyProperty);
       }
    }
