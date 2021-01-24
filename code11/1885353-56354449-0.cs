    public List<CityViewModel> GetCities()
    {
        var cities = cityRepository.GetAll();
        List<CityViewModel> cityViewModelList = new List<CityViewModel>();
        foreach(var city in cities)
        {
            CityViewModel cityViewModel = new CityViewModel
            {
                //map your properties
            }
            cityViewModelList.Add(cityViewModel);
        }
        return cityViewModelList;
    }
