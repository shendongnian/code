    private IList<FindingStatus> _findingStatuses;
    public IList<FindingStatus> FindingStatuses
    {
        get 
        {
            if (_findingStatuses == null) 
            {
                 _findingStatuses = FindingStatusService.GetAvalableStatuses(CompanyId);
            }
            return _findingStatuses;
        }
    }
