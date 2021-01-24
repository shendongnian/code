    public class ViewModel : INotifyPropertyChanged
    {
      public ViewModel()
      {
        this.DataTable = new DataTable();
      }
    
      private void InitGridFromXML(string xmlPath)
      {
        var xmlEntities = XElement.Load(xmlPath).Elements().ToList();
        var dataTable = new DataTable();
        dataTable.Columns.AddRange(
          xmlEntities
            .FirstOrDefault()?
            .Elements()
            .Select(node => new DataColumn(node.Name.LocalName))
            .ToArray());
        foreach (XElement xElement in xmlEntities)
        {
          dataTable.Rows.Add(
            xElement.Elements()
              .Select(node => node.Value)
              .ToArray());
        }
        this.DataTable = dataTable;
      }
      private DataTable dataTable;  
      public DataTable DataTable
      {
        get => this.dataTable;
        set
        {
          this.dataTable = value; 
          OnPropertyChanged();
        }
      }
      public event PropertyChangedEventHandler PropertyChanged;
      protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
      {
        this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
      }
    }
