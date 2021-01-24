    public partial class UserControl1 : UserControl,IRequireGraphicInterface
    {  
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Opcconnect OC = new Opcconnect();
            var values = OC.DataRead();
            txtBox2.Text = values.Item1;
            txtBox3.Text = values.Item2;
            txtBox4.Text = "zjy";
        }
    }
