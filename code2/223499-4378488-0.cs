    public event EventHandler BeforeSearch;
    public event EventHandler AfterSearch;
    public void ExecuteSearch(...)
    {
        if (this.BeforeSearch != null)
          this.BeforeSearch();
        // Do search
        if (this.AfterSearch != null)
          this.AfterSearch();
    }
