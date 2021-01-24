     <div class="form-group row">
        <label class="col-2 col-form-label" for="PartnerInput">Partner:</label>
        <input id="PartnerInput" list="Partners" @onchange="@((args) => name = args.Value.ToString())" />
        <datalist class="col-4" id="Partners">
            @foreach (var partner in partners)
            {
                <option value="@partner.Name"></option>
                
            }
        </datalist>
        @if (SelectedPartner != null)
        {
        <label class="col-auto col-form-label">@($"Partner Name: {SelectedPartner.Name}, Partner ID: {SelectedPartner.Code}")</label>
        }
    </div>
    @code {
    private List<Partner> partners;
    private string name;
    private Partner SelectedPartner => partners.Where(a => a.Name == name).FirstOrDefault();
    
    protected override void OnInitialized()
    {
        partners = Enumerable.Range(1, 10).Select(i => new Partner { Code = i.ToString(), Name = $"Partner {i.ToString()}" }).ToList();
    }
    public class Partner
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
    }
