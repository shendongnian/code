        personList = picp.GetPersonsInChargeList();  // got 6000++ records
        clientList = (List<ClientEntity>)cp.GetClientList();  // got 5000 ++ records after step thru
        //PicList sdf;
        var returnList = (from PersonsInChargeEntity pic in personList
                         join ClientEntity client in clientList
                         on pic.ClientNumber equals client.ClientNumber
                         select new PicList { ClientNumber = pic.ClientNumber, CompanyName = client.CompanyNameFull, AICGroupID = pic.AICStaffGroupID, RPStaffID = pic.RPStaffID, 
                         MPStaffID = pic.MPStaffID, CSPStaffID = pic.CSPStaffID, EQCRStaffID = pic.EQCRStaffID }).ToList();
