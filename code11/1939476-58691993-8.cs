    public class addReorderViewModel
    {
      public addReorderViewModel()
      {
        InitializeReorderModel(/* pass in 'hv' string */);
        this.Artikel = new ArtikelViewModel();
        //Die Anforderungscollection wird befüllt         
        IAnforderungsgrund anfgruende = new Anforderungsgrund();
        this.AnfCollection = anfgruende.ListeAnforderungen();        
      }
      public InitializeReorderModel(string hv)
      {
        this.Nachbest = new ReorderViewModel();
            
        //HV, BV, Projektleiter und Bauleiter holen
        var dbOracle = new Datenbank();
        this.Nachbest.BV = dbOracle.GetBauvorhaben(hv);
        this.Nachbest.Hv = hv;
        this.Nachbest.Bauleiter = dbOracle.GetBauleiter(hv);
        this.Nachbest.Projektleiter = dbOracle.GetProjektleiter(hv);
      }
    
      private void ExecuteMethods(object param)
      { 
        var mongo = DbConn(); //Connection to MongoDB
        var artikel = this.Artikel; //returns ObservableCollection<ArtikelModel>
        var reorder = this.Nachbest; //returns ReorderModel
        Insert(mongo, artikel, reorder); //inserts new reorder into the MongoDB database (one reorder has multiple articles(artikel))
      }
      public ICommand SaveNb => new DelegateCommand<object>(ExecuteMethods, CanExecuteMethods);
      public ReorderViewModel Nachbest {get; set;}
      public ArtikelViewModel Artikel {get; set;}
      public ObservableCollection<string> AnfCollection {get; set;}      
    }
