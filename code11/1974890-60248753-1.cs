    public PartialViewResult OnGetReloadCompaniesInAreaList(string companyInSearchAreaViewModels)
    {
                List<CompanyInSearchAreaViewModel> data = JsonConvert.DeserializeObject<List<CompanyInSearchAreaViewModel>>(companyInSearchAreaViewModels);
    
                var result = new PartialViewResult
                {
                    ViewName = "_CompaniesInAreaList",
                    ViewData = new ViewDataDictionary<IList<CompanyInSearchAreaViewModel>>(ViewData, data)
                };
    
                return result;
    }
