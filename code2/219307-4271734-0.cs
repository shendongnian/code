    public class Contact : IDataErrorInfo, INotifyPropertyChanged
    {
         private string firstName;
         public string FirstName
         {
             // ... set/get with prop changed support
         }
         #region IDataErrorInfo Members
         public string Error
         {
             // NOT USED BY WPF
             get { throw new NotImplementedException(); }
         }
         public string this[string columnName]
         {
            get 
            {
                // null or string.Empty won't raise a validation error.
                string result = null;
                if( columnName == "FirstName" )
                {
                    if (String.IsNullOrEmpty(FirstName))
                         result = "A first name please...";
                    else if (FirstName.Length < 5)
                         result = "More than 5 chars please...";
                 }
                return result;
        }
    }
    #endregion
}
