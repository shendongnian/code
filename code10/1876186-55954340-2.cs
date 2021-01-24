    @page "/counter"
    @using BlazorServiceTest
    @inject IWebCrawlServiceAsync WebCrawler
    
    <h1>Counter</h1>
    
    <p>Current count: @debug</p>
    
    <button class="btn btn-primary" onclick="@IncrementCount">Click me</button>
    
    @functions {
        string debug { get; set; } = "";
    
        async Task IncrementCount() { //<-- Note Change here
            debug = await WebCrawler.GetWeb();
            // Note that the following line is necessary because otherwise
            // Blazor would not recognize the state change and not refresh the UI
            this.StateHasChanged();
        }
    }
