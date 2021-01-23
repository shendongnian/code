    using System;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    
    namespace yourNameSpace
    {
        public class Myform : Form
        {
            
            private void someFuncInvokedByTimerOnMainThread()
            {
                bool isVisible = isControlVisible(this);
                // do something.
            }
    
            [DllImport("user32.dll")]
            static extern IntPtr WindowFromPoint(System.Drawing.Point p);
    
    
            ///<summary><para>------------------------------------------------------------------------------------</para>
            ///
            ///<para>           Returns true if the control is visible on screen, false otherwise.                </para>
            ///
            ///<para>------------------------------------------------------------------------------------</para></summary>
            private bool isControlVisible(Control control)
            {
                bool result = false;
                if (control != null)
                {
                    var pos = control.PointToScreen(System.Drawing.Point.Empty);
                    var handle = WindowFromPoint(new System.Drawing.Point(pos.X + 10, pos.Y + 10)); // +10 to disregard padding   
                    result = (control.Handle == handle); // should be equal if control is visible
                }
                return result;
            }
        }
    }
