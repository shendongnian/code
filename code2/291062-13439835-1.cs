    using System.Runtime.InteropServices;
    namespace System.Windows.Forms {
        public class LinkLabelEx : LinkLabel {
            private const int IDC_HAND = 32649;
            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            private static extern IntPtr LoadCursor(IntPtr hInstance, int lpCursorName);
            protected override void OnMouseMove(MouseEventArgs e) {
                base.OnMouseMove(e);
                // If the base class decided to show the ugly hand cursor
                if(OverrideCursor == Cursors.Hand) {
                    // Show the system hand cursor instead
                    OverrideCursor = new Cursor(LoadCursor(IntPtr.Zero, IDC_HAND));
                }
            }
        }
    }
