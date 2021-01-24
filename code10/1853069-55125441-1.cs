    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace FormTestLib
    {
        public partial class ValidatingSplash : Form
        {
            public ValidatingSplash()
            {
                InitializeComponent();
    
                AdjustClientWidthToDPIScale();
            }
    
            protected override void OnLoad(EventArgs e)
            {
                base.OnLoad(e);
                this.CenterToParent();
            }
    
            private void AdjustClientWidthToDPIScale()
            {
                double dpiKoef = Graphics.FromHdc(GetDC(IntPtr.Zero)).DpiX / 96f;
    
                int compansatedWidth = (int)(ClientSize.Width * dpiKoef);
                
                
                this.ClientSize = new Size(compansatedWidth, this.ClientSize.Height);
            }
    
            [DllImport("User32.dll")]
            private static extern IntPtr GetDC(IntPtr hWnd);
        }
    }
