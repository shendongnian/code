    var karta = _ecpContext.Karta.Where(f => f.Miesiac == numerMiesiaca && f.Rok == numerRoku && f.Login == userName).OrderBy(x => x.Rok).ThenBy(x => x.Miesiac).ThenBy(x => x.DzMiesiaca).ToList();
    var kartaModel = karta.Select(p => new Karta_Model 
                   { 
                     Id = p.Id // Assign the rest of properties here 
                   }).ToList();
    var viewModel = new ParentView { Model1  = kartaModel  };
    return PartialView("_ReturnView", viewModel);
