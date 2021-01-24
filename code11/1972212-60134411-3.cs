        public void buildOval(int oWDelta, int oHDelta, Control o)
        { 
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddEllipse(0, 0, o.Width - oWDelta, o.Height - oHDelta);
            Region rg = new Region(gp);
            o.Region = rg;
        }
You could now call them the methods as
 buildOval(wDeltaValue,oDeltaValue,this); // when called for Form
 buildOval(wDeltaValue,oDeltaValue,pictureBoxInstance);
 buildOval(wDeltaValue,oDeltaValue,buttonInstance);
