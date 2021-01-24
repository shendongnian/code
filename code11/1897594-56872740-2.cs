    using System.Runtime.InteropServices;
    
    namespace CSharpExampleUsingCpp
    {
        public partial class MainWindow : Window
        {
    const string PATH = "DLLExample.dll";
    
    [DllImport(PATH, CallingConvention = CallingConvention.Cdecl)]
    public static unsafe extern void GetCppText(byte[] str, out System.Int32 strLength);
    
    ....
    
    private void CppInteropButton_Click(object sender, RoutedEventArgs e)
            {
                System.Int32 size = 256;
                System.Byte[] str = new byte[size];
                for (int i = 0; i < size; i++)
                {
                    str[i] = (byte)'1';
                }
    
                GetCppText(str, out size);
                string result = System.Text.Encoding.UTF8.GetString(str, 0, size);
                CppInteropButtonTextBox.Text = result;
    }
