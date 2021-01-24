    public IEnumerable<PERSON> GetSearchResults(SearchViewModel viewModel)
    {
        var people = unitOfWork.PersonRepository.GetAll();
        if (viewModel.Casenote != null)
        {
            var casenoteNos = unitOfWork.CasenoteRepository.GetAll()
                                .Where(x => x.CASENOTE1.Trim()
                                       .ToLower()
                                       .Contains(viewModel.Casenote.Trim().ToLower()))
                                .Select(casenote => casenote.PAS_INT_NO)
                                .Take(1000)
                                .ToList();
    
            if (casenoteNos.Any())
            {
                people = people.Where(w => casenoteNos.Contains(w.PAS_INT_NO));
            }
        }
        return people.Take(1000).ToList().OrderBy(x => x.SURNAME).ThenBy(x => x.FORENAMES);
    }
     
