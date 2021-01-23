    public ActionResult List(Cart cart, string category, int page = 1)
    {
        Dictionary<String, String> selectedItems = new Dictionary<String, String>();
        
        foreach (var line in cart.Lines)
        {
            selectedItems.Add(line.Publication.PDFID.ToString(), line.Quantity.ToString());
        }
    
        foreach (var line in cart.Lines)
        {
            ViewData.Add(line.Publication.PDFID.ToString(), line.Quantity.ToString());
        }
    
        var publicationsToShow = (category == null)
                        ? publicationsRepository.Publications
                        : publicationsRepository.Publications.Where(x => x.Category.Equals(category, StringComparison.CurrentCultureIgnoreCase));
    
        var viewModel = new PublicationsListViewModel
        {
            Publications = publicationsToShow.Skip((page - 1) * PageSize).Take(PageSize).ToList(),
            PagingInfo = new PagingInfo
            {
                CurrentPage = page,
                ItemsPerPage = PageSize,
                TotalItems = publicationsToShow.Count()
            },
            CurrentCategory = category,
            SelectedItems = selectedItems
        };
    
        return View(viewModel); // Passed to view as ViewData.Model (or simply Model)
    }
