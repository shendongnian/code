    public PartialViewResult OnGetReloadCompaniesInAreaList(List<CompanyInSearchAreaViewModel> companyInSearchAreaViewModels)
            {
                var result = new PartialViewResult
                {
                    ViewName = "_CompaniesInAreaList",
                    ViewData = new ViewDataDictionary<IList<CompanyInSearchAreaViewModel>>(ViewData, companyInSearchAreaViewModels)
                };
    
                return result;
            }
