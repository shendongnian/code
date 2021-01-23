    public class Error
    {
        private readonly ErrorProvider errProvider = new ErrorProvider();
        public void SetError(Control control, string value)
        {
            if (control.Text.Trim().Length == 0)
            {
                errProvider.SetError(control, value);
            }
            else
            {
                errProvider.SetError(control, "");
            }
        }
    }
