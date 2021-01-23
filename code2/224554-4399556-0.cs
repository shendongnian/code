    BookmarkDeletedListener listener = new BookmarkDeletedListener(this, bookMarkId);
    bookMarkClient.wmdeleteBookMarkCompleted += listener.DeleteBookmarkCompleted;
    // ...
    class BookmarkDeletedListener
    {
        public BookmarkDeletedListener(ParentClass parent, string bookmarkId)
        {
            _parent = parent;
            _bookmarkId = bookmarkId;
        }
        public DeleteBookmarkCompleted(object sender, wmdeleteBookMarkCompletedEventArgs e)
        {
            if (ea.Result = "Success")
            {
                foreach (BookMark bookMark in BookMarks)
                {
                    if (_bookmarkId == bookMark.bm_id)
                    {
                        _parent.BookMarks.Remove(bookMark);
                        _parent.OnNotifyPropertyChanged("BookMarks");
                        break;
                    }
                }
            }
        }
        readonly ParentClass _parent;
        readonly string _bookmarkId;
    }
