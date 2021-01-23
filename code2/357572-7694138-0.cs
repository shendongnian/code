    private Book _book;
    public Page(Book book, string pagetitle);
    {
       this._book = book
    }
    // Usage in the Book class
    Page pageone = new Page(this, "one");
