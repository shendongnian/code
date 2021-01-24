    @code {
       
        private List<string> listItems = new List<string>();
        protected override async Task OnInitializedAsync()
        {
            //get products
             
            foreach (var product in products)
            {
                string a = "https://localhost:5001/api/Units/";
                a += product.UnitID.ToString();
                var temp = await Http.GetJsonAsync<Unit>(a); 
                             
               listItems.Add(temp.Name);
            }
        }
    }
