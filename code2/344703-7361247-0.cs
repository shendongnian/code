    public class MyTextBox : TextBox
    {
       public override string Text
       {
          get
          {
             return base.Text;
          }
          set
          {
             base.Text = value;
             UpdateTextboxWidth();
          }
       }
       void UpdateTextboxWidth()
       {
          using (Graphics graphics = CreateGraphics())
          {
             int text_width = TextRenderer.MeasureText(graphics, base.Text, Font,
                 ClientSize, TextFormatFlags.NoPadding).Width;
 
             Width = text_width + Margin.Left + Margin.Right;
          }
       }
    }
