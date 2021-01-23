    if (!_serviceContext.IsSubmitting)
    {
        _serviceContext.SubmitChanges();
    }
    else
    {
        PropertyChangedEventHandler propChangedDelegate = null;
        propChangedDelegate = delegate
            {
                if (!_serviceContext.IsSubmitting)
                {
                    _serviceContext.SubmitChanges();
                    _serviceContext.PropertyChanged -= propChangedDelegate;
                }
            };
        _serviceContext.PropertyChanged += propChangedDelegate;
       
    }
