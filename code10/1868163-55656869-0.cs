    public class ViewModel
    {
        public DelegateCommand OpenDialogCommand { get; set; }
        public ViewModel()
        {
            OpenDialogCommand = new DelegateCommand(BrowseFile);
        }
        private void BrowseFile()
        {
            var openDialog = new OpenFileDialog()
            {
                Title = "Choose File",
                // TODO: etc v.v
            };
            openDialog.ShowDialog();
            if (File.Exists(openDialog.FileName))
            {
                // TODO: Code logic is here
            }
            else
            {
                // TODO: Code logic is here
            }
        }
    }
`
