    public class ValidationHelper
    {
        private static ErrorProvider errProvider = new ErrorProvider();
        public static void ValidateFields(List<Control> controls)
        {
            errProvider.Clear();
            foreach (Control c in controls)
            {
                errProvider.SetError(c, "");
                if (string.IsNullOrWhiteSpace(c.Text))
                {
                    errProvider.SetError(c, "Please fill the required field");
                }
            }
        }
    }
