    public partial class AddDocumentsDialog : IResetCategoryControl
    {
        private string categoryToAdd;
        public string CategoryToAdd
        {
            set
            {
                // do some logic to validate the value
                categoryToAdd = value;
            }
        }
    }
