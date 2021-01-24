    public IEnumerable<PERSON> GetSearchResults(SearchViewModel viewModel)
    {
        var people = unitOfWork.PersonRepository.GetAll();
        if (viewModel.Casenote != null)
        {
            var casenotes = unitOfWork.CasenoteRepository.GetAll()
                                .Where(x => x.CASENOTE1.Trim()
                                       .ToLower()
                                       .Contains(viewModel.Casenote.Trim().ToLower()))
                                .Take(1000)
                                .ToList();
    
            var result = people.Take(0).ToList();
            if (casenotes.Count > 0)
            {
                foreach (var casenote in casenotes)
                {
                    var pasint = casenote.PAS_INT_NO;
                    result.AddRange(people.Where(w => w.PAS_INT_NO == pasint));
                    //it gives me the stackoverflow.exception at execution of the above line
                } 
            }
            people = result;
        }
        return people.Take(1000).ToList().OrderBy(x => x.SURNAME).ThenBy(x => x.FORENAMES);
    }
     
