    ObservableCollection<SupportingObjects.StaffIncentiveHelperObject> myIcentives = new ObservableCollection<SupportingObjects.StaffIncentiveHelperObject>();
    foreach (staffincentive SI in db_incentives)
    {
        StaffIncentiveHelperObject SIHO = new StaffIncentiveHelperObject(SI);
        myIcentives.Add(SIHO);
        foreach (staffincentiveline SIL in SI.staffincentiveline)
        {
            SIHO.AddStaffIncentiveLine(SIL);
        }
    }
