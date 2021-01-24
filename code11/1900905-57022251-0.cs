    var viewModel = new List<ClientIndexViewModel>();
            foreach (var item in my)
            {
                viewModel.Add(new ClientIndexViewModel()
                {
                    Client = item.aClient,
                    Phone = item.aPhone,
                    Consultant = item.aConsultant,
                    Email = item.aEmail,
                    ClientStatus = item.aStatus,
                });
            }
            return View(viewModel);
