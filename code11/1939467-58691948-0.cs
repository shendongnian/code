public addReorderViewModel()
{
    saveNb  = new DelegateCommand<Button>(() =>{
       var mongo = DbConn(); //Connection to MongoDB
       var artikel = GetArtikel(reorderView); //returns ObservableCollection<ArtikelModel>
       var reorder = GetReorder(artikel, reorderView); //returns ReorderModel
       Insert(mongo, artikel, reorder); //inserts new reorder into the MongoDB database (one reorder has multiple articles(artikel))
    });
}
