    public IActionResult GetOffices(){
           List<OfficeViewModel> viewModel = Offices.Select(x => new OfficeViewModel
           {
                Id = x.Id,
                Name = x.Name,
                CityId = x.CityId,
                CityName = Cities.FirstOrDefault(y => y.CityId == x.CityId).CityName
            }).ToList();
            return View(viewModel);
    }
