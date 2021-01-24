    public List<SaleCenterViewModel> GetAllSaleCenters()
    {
        return
            db.SaleCenters
            .Select(SaleCenterViewModel.Set)
            .ToList();
    }
