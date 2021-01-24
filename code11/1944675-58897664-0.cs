    public ViewResult Index(int? Id)
    {
        var users = _userRepository.GetAllUsers();
        var usersForSelectList = users.Select(u => new 
        {
           Id = u.Id,
           DisplayName = u.Name + " " + u.LastName
        }).ToList();
        RegistrationsIndexViewModel viewModel = new RegistrationsIndexViewModel()
        {
            registrations = _registrationRepository.GetAllRegistrations(),
            registration = _registrationRepository.GetRegistration(Id ?? 0),
            
            UsersOptions = new SelectList(usersForSelectList , "Id", "DisplayName"),
        };
        return View(viewModel);
    }
