      private List<string> _refreshProps = new List<string>();
      private bool _showPriority;
      public void Form()
      {
          _refreshProps.Add("ShowPriority");
          ... etc
      }
      
      // only implement properties like this that need some extra work done
      public bool ShowPriority
      {
          get { return _showPriority; }
          set
          {
              if (_showPriority != value)
              {
                  _showPriority = value;
                  // Call OnPropertyChanged whenever the property is updated
                  OnPropertyChanged("ShowPriority");
              }
          }
      }
      // basic property that doesn't require anything extra
      public bool AnotherProperty { get; set; }
      public void Refresh()
      {
          // refresh the form
      }
      protected void OnPropertyChanged(string name)
      {
          if (_refreshProps.Contains(name))
              Refresh();
      }
