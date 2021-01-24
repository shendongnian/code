    @inject HttpClient httpClient
    @if (States != null)
    {
    <select id="SearchStateId" name="stateId" @onchange="@StateChange" class="form-control1">
        <option>@InitialText</option>
        @foreach (var state in States)
        {
            <option value="@state.Name">@state.Name</option>
        }
    </select>
    }
    @code {
    [Parameter] public string SelectedText { get; set; } = string.Empty;
    [Parameter] public string InitialText { get; set; } = "Select State";
    [Parameter] public EventCallback<string> SelectedTextChanged { get; set; }
    private KeyValue[] States;
    protected override async Task OnInitializedAsync()
    {
        States = await httpClient.GetJsonAsync<KeyValue[]>("/sample-data/State.json");
    }
    private async Task StateChange(ChangeEventArgs e)
    {
        //Console.WriteLine("It is definitely: " + e.Value.ToString());
        await SelectedTextChanged.InvokeAsync(e.Value.ToString());
    }
    public class KeyValue
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    }
