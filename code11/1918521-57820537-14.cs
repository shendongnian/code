    class ViewModel
    {
      public ObservableCollection<Folder> Folders { get; set; }
    
      public ViewModel()
      {
        this.Folders = new ObservableCollection<Folder>
        {
          new Folder("Folder_1")
          {
            ChildItems = new ObservableCollection<TreeItem>
            {
              new Folder("Folder_1.1")
              {
                ChildItems = new ObservableCollection<TreeItem>
                {
                  new Folder("Folder_1.1.1")
                  {
                    ChildItems = new ObservableCollection<TreeItem>
                    {
                      new Session("SessionA"),
                      new Session("SeesionB")
                    }
                  },
                  new Session("SessionA"),
                  new Session("SeesionB")
                }
              },
              new Folder("Folder_1.2")
              {
                ChildItems = new ObservableCollection<TreeItem>
                {
                  new Session("SessionA"),
                  new Session("SeesionB")
                }
              }
            }
          }
        };
      }
    }
