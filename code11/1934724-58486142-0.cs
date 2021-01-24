    <select class="form-control" @bind="@SelectedCountryID">
    
        <option value=""></option>
        @foreach(var country in CountryList)
        {
            <option value = "@country.Code"> @country.Name </option >
        }
    }
    
    </select>
    
    <p>@SelectedCountryID</p>
    
    @code {
    
        string selectedCountryID;
    
        string SelectedCountryID
        {
            get => selectedCountryID;
            set
            {
                selectedCountryID = value;
    
            }
        }
    
        List<Country> CountryList = new List<Country>() { new Country ("USA", "United States"),
                                                          new Country ("UK", "United Kingdom") };
    
        public class Country
        {
    
            public Country(string code, string name)
            {
                Code = code;
                Name = name;
            }
            public string Code { get; set; }
            public string Name { get; set; }
    
        }
    }
 
