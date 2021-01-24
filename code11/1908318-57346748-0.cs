    public class ViewModel()
    {
      public ViewModel()
      {
        this.TableXElement = new ObservableCollection<XElement>();
      }
    
      private void InitGridFromXML(string xmlPath)
      {
        this.TableXElement = new ObservableCollection<XElement>(XElement.Load(xmlPath).Elements());
      }
    
      private ObservableCollection<XElement> tableXElement;
      public ObservableCollection<XElement> TableXElement
      {
        get => this.tableXElement;
        set
        {
          this.tableXElement = value; 
          OnPropertyChanged();
        }
      }
    }
