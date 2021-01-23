    public class MainForm
    {
        private SecondForm _secondForm;
         
        public void OpenSecondForm()
        {
             // create it only once
             if (_secondForm == null)
                 _secondForm = new SecondForm();
             // otherwise just show it
             _secondForm.Show();
        }
    }
