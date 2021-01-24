    public class ViewModel : INotifyPropertyChanged, INotifyDataErrorInfo
    {    
      // Usage example property which validates its value 
      // before applying it using a Lambda expression.
      // Example uses System.ValueTuple.
      private string userInput;
      public string UserInput
      { 
        get => this.userInput; 
        set 
        { 
          // Use Lambda
          if (ValidateProperty(value, newValue => newValue.StartsWith("@") ? (true, string.Empty) : (false, "Value must start with '@'.")))
          {
            this.userInput = value; 
            OnPropertyChanged();
          }
        }
      }
      // Alternative usage example property which validates its value 
      // before applying it using a Method group.
      // Example uses System.ValueTuple.
      private string userInputAlternativeValidation;
      public string UserInputAlternativeValidation
      { 
        get => this.userInputAlternativeValidation; 
        set 
        { 
          // Use Method group
          if (ValidateProperty(value, AlternativeValidation))
          {
            this.userInputAlternativeValidation = value; 
            OnPropertyChanged();
          }
        }
      }
      private (bool IsValid, string ErrorMessage) AlternativeValidation(string value)
      {
        return value.StartsWith("@") 
          ? (true, string.Empty) 
          : (false, "Value must start with '@'.");
      }
      private bool TrySave()
      {
        if (this.HasErrors)
        {
          return false;
        }
    
        // View model has no errors. Save data.
        return true;
      }
    
      // Constructor
      public ViewModel()
      {
        this.Errors = new Dictionary<string, List<string>>();
      }
      // Example uses System.ValueTuple
      public bool ValidateProperty(object value, Func<object, (bool IsValid, string ErrorMessage)> validationDelegate, [CallerMemberName] string propertyName = null)  
      {  
        // Clear previous errors of the current property to be validated 
        this.Errors.Remove(propertyName); 
        OnErrorsChanged(propertyName); 
    
        (bool IsValid, string ErrorMessage) validationResult = validationDelegate?.Invoke(value) ?? (true, string.Empty);
    
        if (!validationResult.IsValid)
        {
          AddError(propertyName, validationResult.ErrorMessage);
        } 
    
        return validationResult.IsValid;
      }   
    
      // Adds the specified error to the errors collection if it is not 
      // already present, inserting it in the first position if 'isWarning' is 
      // false. Raises the ErrorsChanged event if the Errors collection changes. 
      public void AddError(string propertyName, string errorMessage, bool isWarning = false)
      {
        if (!this.Errors.TryGetValue(propertyName, out List<string> propertyErrors))
        {
          propertyErrors = new List<string>();
          this.Errors[propertyName] = propertyErrors;
        }
    
        if (!propertyErrors.Contains(errorMessage))
        {
          if (isWarning) 
          {
            // Move warnings to the end
            propertyErrors.Add(errorMessage);
          }
          else 
          {
            propertyErrors.Insert(0, errorMessage);
          }
          OnErrorsChanged(propertyName);
        } 
      }
    
      public bool PropertyHasErrors(string propertyName) => this.Errors.TryGetValue(propertyName, out List<string> propertyErrors) && propertyErrors.Any();
    
      #region INotifyDataErrorInfo implementation
    
      public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
    
      public System.Collections.IEnumerable GetErrors(string propertyName) 
        => this.Errors.TryGetValue(propertyName, out List<string> propertyErrors)) 
          ? propertyErrors
          : new List<string>();
    
      public bool HasErrors => this.Errors.Any(); 
    
      #endregion
    
      #region INotifyPropertyChanged implementation
    
      public event PropertyChangedEventHandler PropertyChanged;
    
      #endregion
    
      protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
      {
        this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
      }
    
      protected virtual void OnErrorsChanged(string propertyName)
      {
        this.ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
      }
    
      // Maps a property name to a list of errors that belong to this property
      private Dictionary<String, List<String>> Errors { get; }    
    }
