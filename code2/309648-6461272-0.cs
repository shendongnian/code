    public class MyButton : Button 
    {
        protected override void OnPaint(PaintEventArgs pe)
        {
            Graphics g = pe.Graphics;
            
            SizeF stringSize = g.MeasureFont(this.Text, this.Font);
            this.Resize(SizeF.Width + 10, SizeF.Height + 10);
         }
    }
