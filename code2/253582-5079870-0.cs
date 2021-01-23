    var dinner = dinnerRepository.Get(dinnerId);
    var bar = barRepository.Get(barId);
    
    var viewModel = new DinnerAndBarFormViewModel(dinner, bar);
    return View(viewModel);
