    public partial class Form1
    {
       public string TextWrapper
       { 
         get
         {
           return this.textBox.Text;
         }
      
      set
         {
             this.textBox.Text = value;
         }
    }
