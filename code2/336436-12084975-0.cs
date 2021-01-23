    var btn = new ImageButton();
    btn.Name = "link1";
    btn.Text = controlText;
    btn.Click += new EventHandler(btn_Click);
    vstoWorksheet.Controls.AddControl(pic, nativeWorksheet.Range[address], controlText);
    
    
     public class ImageButton : Control, IButtonControl
        {
            public ImageButton()
            {
                SetStyle(ControlStyles.SupportsTransparentBackColor, true);
                SetStyle(ControlStyles.Opaque, true);
                SetStyle(ControlStyles.ResizeRedraw, true);
                this.BackColor = Color.Transparent;
    
            }
    
            protected override void OnPaint(PaintEventArgs pevent)
            {
                Graphics g = pevent.Graphics;
                g.DrawRectangle(Pens.Black, this.ClientRectangle);
            }    
    
            protected override void OnPaintBackground(PaintEventArgs pevent)
            {
                // don't call the base class
                //base.OnPaintBackground(pevent);
            }    
    
            protected override CreateParams CreateParams
            {
                get
                {
                    const int WS_EX_TRANSPARENT = 0x20;
                    CreateParams cp = base.CreateParams;
                    cp.ExStyle |= WS_EX_TRANSPARENT;
                    return cp;
                }
            }    
            // rest of class here...          
        }
