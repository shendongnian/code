    public class MyTextBox : TextBox
    {
       public MyTextBox() 
       {
          myBackColor = "Red";
       }
    
       private Color myBackColor
    
       [ReadOnly]
       public Color BackColor
       { get { return myBackColor; } }
    
       public void SetNewBackColor( Color anyNewColor )
       {
          myBackColor = anyNewColor;
       }
    }
