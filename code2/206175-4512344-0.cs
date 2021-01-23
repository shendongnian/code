    public class StringsWrapper
    {
        private static LibraryItemDetailsView _view = null;
        
        public LibraryItemDetailsView View
        {
            get
            {
                if (_view == null)
                {
                    _view = new LibraryItemDetailsView();
                }
                return _view;
            }
        }
    }
