    public partial class AddDocumentsDialog : IResetCategoryControl
    {
       private string _categoryToAdd = "";
       public string CategoryToAdd
       {
         set
         {
            _categoryToAdd = value;
         }
       }
    }
