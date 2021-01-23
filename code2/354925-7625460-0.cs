      using System.ComponentModel;
      using System.Data;
      using System.Drawing;
      using System.Linq;
      using System.Text;
      using System.Windows.Forms;
      using System.Runtime.InteropServices;
 
    namespace WindowsFormsApplication1
    {
       public partial class Form1 : Form
       {
           public Form1()
           {
                InitializeComponent();            
           }
 
          private void button1_Click(object sender, EventArgs e)
          {
            
            MessageBox.Show(GetFocusControl());
          }
 
          [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
          internal static extern IntPtr GetFocus();
 
          private string GetFocusControl()
          {
            Control focusControl = null;
            IntPtr focusHandle = GetFocus();
            if (focusHandle != IntPtr.Zero)
                focusControl = Control.FromHandle(focusHandle);
            if (focusControl.Name.ToString().Length == 0)
                return focusControl.Parent.Parent.Name.ToString();
            else
                return focusControl.Name.ToString();
          }
       }
     }
