    var oldDbContractItem = vendorContract.Item
      .Where(x => x.ItemNumber == contractItem.Item_Number).FirstOrDefault();
    if(oldDbContractItem != null) //would be null if there are no items
    {
      // check to see if there were changes
      if (oldDbContractItem.DateStamp != vendorContractItem.Date_Stamp)
      {
        oldDbContractItem.Update(vendorContractItem);
      }
    }
    }
