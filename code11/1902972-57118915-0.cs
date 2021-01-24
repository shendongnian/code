    var countriesTask = client.GetAsync("countries");
    var statesTask = client.GetAsync("states");
    var citiesTask = client.GetAsync("cities");
    var residuesTask = client.GetAsync("residues");
    
    await Task.WhenAll(countriesTask, statesTask, citiesTask, residuesTask);
    
    viewModel.Countries = countriesTask.Result.Content.ReadAsAsync<List<Country>>();
    viewModel.States = statesTask.Result.Content.ReadAsAsync<List<State>>();
    viewModel.Cities = citiesTask.Result.Content.ReadAsAsync<List<City>>();
    viewModel.Residues = residuesTask.Result.Content.ReadAsAsync<List<SiteResidue>>();
    
    return View(viewModel);
