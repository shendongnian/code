    var building = context.Buildings.Where(x => x.Name == "Building 1")
       .Select(x => new BuildingViewModel
       {
          Name = x.Name,
          Country = x.City.State.Country.Select(c => new BuildingCountryViewModel
          {
              Text = c.Text,
              Value = c.Value,
              State = x.City.State.Select(s => new BuildingStateViewModel
              {
                 Text = s.Text,
                 Value = s.Value,
                 City = x.City.Select(ci => new BuildingCityViewModel
                 {
                    Text = ci.Text
                 }
              }
           }
        }).Single();
