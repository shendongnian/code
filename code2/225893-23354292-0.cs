    public class CustomLabel : Label
        {
            protected override void OnPaint(PaintEventArgs e)
               {
                 base.OnPaint(e);
                 ControlPaint.DrawBorder(e.Graphics, ClientRectangle,
                                              Color.Red, 5, ButtonBorderStyle.Solid,
                                              Color.Red, 5, ButtonBorderStyle.Solid,
                                              Color.Red, 5, ButtonBorderStyle.Solid,
                                              Color.Red, 5, ButtonBorderStyle.Solid);
               } 
        }
