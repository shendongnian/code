    namespace WindowsFormsApp1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                var encrypted = GoFunctions.Encrypt(System.Text.Encoding.UTF8.GetBytes("hello"));
                var decrypted = GoFunctions.Decrypt(System.Text.Encoding.UTF8.GetBytes(Marshal.PtrToStringAnsi(encrypted)));
                label1.Text = Marshal.PtrToStringAnsi(encrypted);
                label2.Text = Marshal.PtrToStringAnsi(decrypted);
            }
    
            static class GoFunctions
            {
                [DllImport(@"C:\Repos\Go_AES\test.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
                public static extern IntPtr Encrypt(byte[] message);
    
                [DllImport(@"C:\Repos\Go_AES\test.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
                public static extern IntPtr Decrypt(byte[] encrypted_message);
            }
        }
    }
