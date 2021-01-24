    [DisableFilter(DataFilter.MustHaveTermId)]
    [DisableFilter(DataFilter.SomeFilter)]
    private Task<List<TermUserEmailInformationDto>> GetAllTermUserEmailAddressesHedefBelirlemeDirektorVeUstu()
    {
        Task<List<TermUserEmailInformationDto>> result = null;
        _unitOfWorkManager.DoWithFilters(() =>
        {
            Console.WriteLine("Performing GetAllTermUserEmailAddressesHedefBelirlemeDirektorVeUstu");
            // Code goes on...
        });
        return result;
    }
