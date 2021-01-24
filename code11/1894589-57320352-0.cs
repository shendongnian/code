@using Newtonsoft.Json
....
@code{
protected override async Task OnInitAsync()
    {
       
        {
            dataSource = JsonConvert.DeserializeObject<ChartData[]>(System.IO.File.ReadAllText("./wwwroot/chartdata.json"));
        }
    }
}
