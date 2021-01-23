    ObservableCollection<SupportingObjects.StaffIncentiveHelperObject> myIcentives = new ObservableCollection<SupportingObjects.StaffIncentiveHelperObject>();
    foreach (staffincentive SI in db_incentives)
    {
        ATG.ClientSide.SupportingObjects.StaffIncentiveHelperObject SIHO = new ATG.ClientSide.SupportingObjects.StaffIncentiveHelperObject(SI);
        myIcentives.Add(SIHO);
        foreach (staffincentiveline SIL in SI.staffincentiveline)
        {
            SIHO.AddStaffIncentiveLine(SIL);
        }
    }
