    public class CreateEntity
    {
        [Required]
        public string Name { get; set; }
        public CreateLocation Place { get; set; }
    }
    public class CreateLocation
    {
        public CreateLocation(Location location = null)
        {
            if (location != null)
            {
                Country = location.Country;
                State = location.State;
                City = location.City;
            }
        }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public IEnumerable<SelectListItem> CountryList
        {
            get
            {
                var list = new[]
                {
                    new SelectListItem() { Text = "US", Value = "US" },
                    new SelectListItem() { Text = "BR", Value = "BR" },
                    new SelectListItem() { Text = "ES", Value = "ES" },
                };
                var selected = list.FirstOrDefault(o => o.Value == Country);
                if (selected != null)
                {
                    selected.Selected = true;
                }
                return list;
            }
        }
        public IEnumerable<SelectListItem> StateList
        {
            get
            {
                var list = new[]
                {
                    new SelectListItem() { Text = "A", Value = "A" },
                    new SelectListItem() { Text = "B", Value = "B" },
                    new SelectListItem() { Text = "C", Value = "C" },
                };
                var selected = list.FirstOrDefault(o => o.Value == State);
                if (selected != null)
                {
                    selected.Selected = true;
                }
                return list;
            }
        }
        public IEnumerable<SelectListItem> CityList
        {
            get
            {
                var list = new[]
                {
                    new SelectListItem() { Text = "X", Value = "X" },
                    new SelectListItem() { Text = "Y", Value = "Y" },
                    new SelectListItem() { Text = "Z", Value = "Z" },
                };
                var selected = list.FirstOrDefault(o => o.Value == City);
                if (selected != null)
                {
                    selected.Selected = true;
                }
                return list;
            }
        }
    }
