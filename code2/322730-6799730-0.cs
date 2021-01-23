    public class MyUserControlDesigner : ScrollableControlDesigner
    {
       public MyUserControlDesigner()
       {
          base.AutoResizeHandles = true;
       }
    
       protected override void OnPaintAdornments(PaintEventArgs p)
       {
          // Get the user control that we're designing.
          UserControl component = (UserControl)base.Component;
          // As you mentioned, no reason to draw this border unless the
          // BorderStyle property is set to "None"
          if (component.BorderStyle == BorderStyle.None)
          {
             this.DrawBorder(p.Graphics);
          }
          // Call the base class.
          base.OnPaintAdornments(p);
       }
       protected virtual void DrawBorder(Graphics g)
       {
          // Get the user control that we're designing.
          UserControl component = (UserControl)base.Component;
          // Ensure that the user control we're designing exists and is visible.
          if ((component != null) && component.Visible)
          {
             // Draw the dashed border around the perimeter of its client area.
             using (Pen borderPen = this.BorderPen)
             {
                Rectangle clientRect = this.Control.ClientRectangle;
                clientRect.Width--;
                clientRect.Height--;
                g.DrawRectangle(borderPen, clientRect);
             }
          }
       }
    
       protected Pen BorderPen
       {
          get
          {
             // Create a Pen object with a color that can be seen on top of
             // the control's background.
             return new Pen((this.Control.BackColor.GetBrightness() < 0.5) ?     
                             ControlPaint.Light(this.Control.BackColor)
                             : ControlPaint.Dark(this.Control.BackColor))
                             { DashStyle = DashStyle.Dash };
          }
       }
    }
    
