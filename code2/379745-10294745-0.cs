    public ViewResult Index()
        {
            IList<City> cities = db.Cities.ToList();
            IList<CityViewModel> viewModelList = Mapper.Map<IList<City>, IList<CityViewModel>>(cities);
            return View(viewModelList);
        }
