    foreach (var item in listt)
    {
           responseUsers.Add(new ResponseUserModel
           {
               ProducerName = item.ProducerName,
               ResidentState = item.ResidentState,
               ResidentCity = item.ResidentCity,
               ProducerStatus = item.ProducerStatus,
               ProducerCode = item.ProducerCode,
               MasterCode = item.MasterCode,
               NationalCode = item.NationalCode,
               LegacyChubbCodes = item.LegacyChubbCodes,
               LegacyPMSCode = item.LegacyPMSCode,                  
               ProducingBranchCode = item.ProducingBranchCode,
               CategoryCode = item.CategoryCode
           });
    }
    return responseUsers;
