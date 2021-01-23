    namespace FadeInAndOutWindow
{
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }
        private bool closeCompleted = false;
        
        private void FormFadeOut_Completed(object sender, EventArgs e)
        {
            closeCompleted = true;
            this.Close();
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!closeCompleted)
            {
                FormFadeOut.Begin();
                e.Cancel = true;
            }
        }
       
    }
