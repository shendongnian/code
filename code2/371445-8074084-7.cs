    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using SPaint; 
    
    namespace YourProject
    {
        public class MyPanel : System.Windows.Forms.Panel
        {
            public MyPanel()
            {
                this.SetStyle(
                    System.Windows.Forms.ControlStyles.UserPaint | 
                    System.Windows.Forms.ControlStyles.AllPaintingInWmPaint | 
                    System.Windows.Forms.ControlStyles.OptimizedDoubleBuffer, 
                    true);
            }
        }
    }
