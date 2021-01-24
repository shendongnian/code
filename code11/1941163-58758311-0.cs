    [BindProperty]
            public List<Motif> ListMotifs { get; set; }
     public void OnGet(string returnUrl = null)
            {
         
    
                ListMotifs = _context.Motif.ToList();
                ReturnUrl = returnUrl;
             }
     @for (var i = 0; i < Model.ListMotifs.Count; i++)
                    {
                        <div class="form-check">
                            <input type="checkbox" name="IsChecked_@i" asp-for="ListMotifs[i].IsChecked" /> @Model.ListMotifs[i].CodeMotif @Model.ListMotifs[i].NomMotif <br />
                        </div>
                    }
