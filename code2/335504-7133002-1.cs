          class MyDataObjectProxy: IPropertyChangedNotification
          {
              MyDataObjectProxy(MyDataObject model)
             {
                 _model = model;
                 _editedStartDate = model.StartDate;
                 _editedEndDate = model.EndDate;
             }
              MyDataObject _model;
              public DateTime StartDate
              {
                 get
                 {
                     return Math.Min(editedStartDate, editedEndDate); 
                 }
                 set 
                 {
                     _editedStartDate = value; 
                     RaisePropertyChanged("StartDate");
                     RaisePropertyChanged("EndDate");
                 }
              }  
              public DateTime EndDate
              {
                 get
                 {
                     return Math.Max(editedStartDate, editedEndDate); 
                 }
                 set 
                 {
                     _editedEndDate = value; 
                     RaisePropertyChanged("StartDate");
                     RaisePropertyChanged("EndDate");
                 }
              }  
              DateTime _editedStartDate;
              DateTime _editedEndDate;
              public void ApplyChanges()
              {
                   DateTime start = StartDate;
                   DateTime end = EndDate;
                  _data.StartDate = start;
                  _data.EndDate = end;
              }
