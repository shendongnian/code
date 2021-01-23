    public class ViewModel2 : ProcessStringViewModel
    {
        public ViewModel2()
        {
            this.ProcessMyStringCommand = new RelayCommand(SomeOtherFunction);
        }
        private void SomeOtherFunction()
        {
            MessageBox.Show("Call of some function");
        }
    }
