    class DataClass {
       string ID { get; set; }
       ...
    }
    
    ...
    
    DataClass current = (DataClass)dataGrid.SelectedItem;
    string id = current.ID;
