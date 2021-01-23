    public class UserControl1 : UserControl
    {
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            MessageBox.Show("Key Down Fired!");
        }
        public void InvokeOnKeyDown(KeyEventArgs e)
        {
            OnKeyDown(e);
        }
    }
