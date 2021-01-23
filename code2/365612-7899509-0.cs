    using System.Windows.Forms;
    namespace WindowsFormsApplication1
    {
        public class MessageBoxObject
        {
            public string Text { get; set; }
            public string Caption { get; set; }
            public MessageBoxButtons Buttons { get; set; }
            public void Show()
            {
                MessageBox.Show(Text,Caption,Buttons);
            }
        }
    }
