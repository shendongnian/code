    public ICommand SaveNb => new DelegateCommand(ExecuteMethods, CanExecuteMethods);
    
    private void ExecuteMethods(object param)
    { 
      var mongo = DbConn(); //Connection to MongoDB
      var artikel = GetArtikel(reorderView); //returns ObservableCollection<ArtikelModel>
      var reorder = GetReorder(artikel, reorderView); //returns ReorderModel
      Insert(mongo, artikel, reorder); //inserts new reorder into the MongoDB database (one reorder has multiple articles(artikel))
    }
    
    private bool CanExecuteMethods(object param)
    { 
      // Check if command can execute 
      if (MongoDb connection exists)
      {
        return true;
      }
      return false;
    }
