    public class Form2 : form
    {
       public string ShowMe {get;set;}
       private void Form2_Load(object sender, EventArgs e)
       {
           MessageBox.Show(ShowMe);
    
       }
    
    }
