      public IActionResult List() {
        // for id in [0..1000] range we collect all corresponding FilialeVM items
        var listafiliali = Enumerable
          .Range(0, 1000 + 1)
          .SelectMany(id => _repoFil
             .GetById(id)                                 // items correspond to given id
             .Result
             .Select(fil => _mapper.Map<FilialeVM>(fil))) // mapped to FilialeVM
          .ToList();                                      // organized as list
        // If we have any item in listafiliali, view them, otherwise use default View()
        return listafiliali.Any()
          ? View(listafiliali)
          : View();
      } 
