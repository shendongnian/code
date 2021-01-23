    public class MyMessageBox : Form
    {
        // You can add parameters here if needed
        public static string Ask()
        {
            var form = new MyMessageBox();
            form.ShowDialog();
            return form.ResponseTextBox.Text;
        }
        // regular stuff
    }
