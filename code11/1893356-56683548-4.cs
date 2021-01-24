      using System.Linq;
      ...
      public IActionResult List(int id) {
        // for given id we collect all corresponding FilialeVM items
        var listafiliali = _repoFil
          .GetById(id)                                // items correspond to given id
          .Result
          .Select(fil => _mapper.Map<FilialeVM>(fil)) // mapped to FilialeVM
          .ToList();                                  // organized as list
        // If we have any item in listafiliali, view them, otherwise use default View()
        return listafiliali.Any()
          ? View(listafiliali)
          : View();
      } 
