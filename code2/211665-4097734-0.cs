    //ViewModelBase should be a base class that implements INotifyPropertyChanged
    public class MyViewModel : ViewModelBase
    {
         public readonly IDataProvider _provider;
    
         public MyViewModel(IDataProvider provider)
         {
             _provider = provider ?? (some default provider);
         }
    
         public IList<String> Titles
         {
             get
             {
                  var q = from shelves in _provider.GetBookShelves()
                          from books in shelves.booksOnThisShelf
                          select books.Title;
    
                  return q as List<String>;
             }
         }
    }
