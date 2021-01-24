    <StateDropdown @bind-SelectedText="@searchFilter.State" InitialText="All India"></StateDropdown>
    <input type="button" id="btnSearch" class="btn-default form-control1" @onclick="@SearchAdertisements" value="Search" />
    @code {
     private SearchFilter searchFilter = new SearchFilter();
     public class SearchFilter
    {
        public string State { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
    }
    private async Task SearchAdertisements()
    {
        Console.WriteLine(searchFilter.State);
    }
