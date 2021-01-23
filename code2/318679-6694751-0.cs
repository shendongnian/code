    public IList<ValidationFailure> ValidationErrors
    {
      get { return GetPropertyValue(() => ValidationErrors); }
      protected set
      {
        List<string> obsoleteValidationErrors = null;
    
        // collect names of properties that do not longer have errors
    #if SILVERLIGHT
        if (ErrorsChanged != null)
    #else
        if (PropertyChanged != null)
    #endif
        {
          var oldErrorsCollection = ValidationErrors != null && ValidationErrors.Count > 0 ? ValidationErrors : new List<ValidationFailure>();
          var newErrorsCollection = value != null && value.Count > 0 ? value : new List<ValidationFailure>();
          var newPropertyNames = newErrorsCollection.Select(x => x.PropertyName).Distinct().ToDictionary(x => x);
    
          // figure out which errors are no longer part of the new validation error collection
          obsoleteValidationErrors = oldErrorsCollection.Where(x =>
            !newPropertyNames.ContainsKey(x.PropertyName)).Select(x => x.PropertyName).Distinct().ToList();
        }
    
        if (SetPropertyValue(() => ValidationErrors, value))
        {
          // fire event for properties that do not longer have errors
          if (obsoleteValidationErrors != null)
          {
            foreach (var obsoleteValidationErrorPropertyName in obsoleteValidationErrors)
    #if SILVERLIGHT
              ErrorsChanged(this, new DataErrorsChangedEventArgs(obsoleteValidationErrorPropertyName));
    #else
              OnPropertyChanged(obsoleteValidationErrorPropertyName);
    #endif
          }
    
          // fire event for properties that now have errors
    #if SILVERLIGHT
          if (value != null && ErrorsChanged != null)
    #else
          if (value != null && PropertyChanged != null)
    #endif
          {
            var propertyNames = value.Select(x => x.PropertyName).Distinct().ToList();
    
            foreach (var failedProperty in propertyNames)
    #if SILVERLIGHT
              ErrorsChanged(this, new DataErrorsChangedEventArgs(failedProperty));
    #else
              OnPropertyChanged(failedProperty);
    #endif
          }
        }
      }
    }
