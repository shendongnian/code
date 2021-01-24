    @using System.IO;
    @page "/dataview"
    @inject HttpClient Http
    
    @if (data == null)
    {
        <p><em>Loading...</em></p>
    }
    else
    {
        <p>@data.Name</p>
    }
    
    @functions {
        DataClass data;
    
        protected override async Task OnInitAsync()
        {
            data = await Http.GetJsonAsync<Dataclass>("api/DataFetcher/GetData");
        }
    }
