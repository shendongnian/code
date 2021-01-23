    Repair existingData = ctn.Repair.FirstOrDefault(a => a.RepairId == item.RepairID && item.ItemID == itemId);
    
        if( existingData!= null)
        {
           existingData.SentForConversion = DateTime.Parse(formValues["SentForConversion"]);
           ctn.SaveChanges();
        }
