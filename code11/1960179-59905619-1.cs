    NAVMENU ----------------------
      <button type="button" class="btn btn-warning border-secondary" @onclick="runSearch">Search</button>
    
    @code {
        public string pageReload = "Search";
    
     private void runSearch()
        {
            if (pageReload == "Search") { pageReload = "search"; } else { pageReload = "Search"; }
            NavigationManager.NavigateTo($"/Page2/{pageReload}", false);
        }
    }
    
    Page 2------------------------------------------------------------------------
    
    @page "/Datatest2/{pageReload}"
    
    <h1>page will now refresh every time</h1>
    
    
    @code{
        [Parameter]
        public string pageReload { get; set; }
    
    }
