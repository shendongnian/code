    public class UsersModel : INotifyDataErrorInfo
    {
      private int id;
      public int Id
      {
        get => this.id; 
        set { if (this.id != value && IsIdValid(value)) this.id = value; }
      }
      private string userName;
      public string UserName
      {
        get => this.userName; 
        set { if (this.userName != value && IsUserNameValid(value) && ) this.userName = value; }
      }
      private string surname;
      public string Surname
      {
        get => this.surname; 
        set { if (this.surname != value && IsSurnameValid(value) && ) this.surname = value; }
      }
      // Validates the Id property, updating the errors collection as needed.
      public bool IsIdValid(int value)
      {
        RemoveError(nameof(this.Id), ID_ERROR);
        if (value < 0)
        {
          AddError(nameof(this.Id), ID_ERROR, false);                 
          return false;
        }
        return true;
      }
      public bool IsUserNameValid(string value)
      {
        RemoveError(nameof(this.UserName), USER_NAME_ERROR);
        if (string.IsNullOrWhiteSpace(value))
        {
          AddError(nameof(this.UserName), USER_NAME_ERROR, false);
          return false;
        }            
        return true;
      }
      public bool IsSurnameValid(string value)
      {
        RemoveError(nameof(this.Surname), SURNAME_ERROR);
        if (string.IsNullOrWhiteSpace(value))
        {
          AddError(nameof(this.Surname), SURNAME_ERROR, false);
          return false;
        }            
        return true;
      }
      private Dictionary<String, List<String>> errors =
            new Dictionary<string, List<string>>();
      private const string ID_ERROR = "Value cannot be less than 0.";
      private const string USER_NAME_ERROR = "Value cannot be empty.";
      private const string SURNAME_ERROR = "Value cannot be empty.";
      // Adds the specified error to the errors collection if it is not 
      // already present, inserting it in the first position if isWarning is 
      // false. Raises the ErrorsChanged event if the collection changes. 
      public void AddError(string propertyName, string error, bool isWarning)
      {
        if (!errors.ContainsKey(propertyName))
          errors[propertyName] = new List<string>();
        if (!errors[propertyName].Contains(error))
        {
          if (isWarning) errors[propertyName].Add(error);
            else errors[propertyName].Insert(0, error);
          
          RaiseErrorsChanged(propertyName);
        }
      }
      // Removes the specified error from the errors collection if it is
      // present. Raises the ErrorsChanged event if the collection changes.
      public void RemoveError(string propertyName, string error)
      {
        if (errors.ContainsKey(propertyName) &&
          errors[propertyName].Contains(error))
        {
          errors[propertyName].Remove(error);
          if (errors[propertyName].Count == 0) errors.Remove(propertyName);
            RaiseErrorsChanged(propertyName);
        }
      }
      public void RaiseErrorsChanged(string propertyName)
      {
        if (ErrorsChanged != null)
          ErrorsChanged(this, new DataErrorsChangedEventArgs(propertyName));
      }
      #region INotifyDataErrorInfo Members
      public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
      public System.Collections.IEnumerable GetErrors(string propertyName)
      {
        if (String.IsNullOrEmpty(propertyName) || 
          !errors.ContainsKey(propertyName)) return null;
        return errors[propertyName];
      }
      public bool HasErrors
      {
        get => errors.Count > 0; 
      }
      #endregion
    }
