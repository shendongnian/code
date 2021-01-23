    using System;
    using System.Drawing;
    using System.Windows.Forms;
    
    namespace lol
    {
        public class BlackWhiteControl : Control
        {
            protected override void OnMouseEnter(EventArgs e)
            {
                base.OnMouseEnter(e);
                
                this.BackColor = Color.Black;
            }
            
            protected override void OnMouseLeave(EventArgs e)
            {
                base.OnMouseLeave(e);
                
                this.BackColor = Color.White;
            }
        }
    }
