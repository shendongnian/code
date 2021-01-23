    DomainContext.PropertyChanged += (c1, c2) =>
                    {
                      if(c2.PropertyName == "IsLoading" || c2.PropertyName == "IsSubmitting")
                        IsBusy = (DomainContext.IsLoading && DomainContext.IsSubmitting);
                    };
