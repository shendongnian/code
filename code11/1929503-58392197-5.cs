    //list order need to sort
    var listNeedToSort = _entites.Order.ToList();
    //list order have before id
    var listBeforeId = listNeedToSort.Where(p=>p.BeforeId!=null).Select(p => p.BeforeId).ToList();
     //count number of duplicate data is not process
     int countLoopDuplicateButNotProcess = 0;
  
      while (listBeforeId.Any())
                    {
                        foreach (var item in listNeedToSort.OrderByDescending(p => p.BeforeId))
                        {
                            if (item.BeforeId != null)
                            {
                                //get record which is mentioned by other record through beforeid.
                                var recordSummary = listNeedToSort.FirstOrDefault(p => p.Id == item.BeforeId);
                                if (recordSummary != null)
                                {
                                    // if sequence number of item with before id greater than record which has id equals beforeid
                                    if (item.Seq > recordSummary.Seq)
                                    {
                                        //reset count loop but it process again
                                        countLoopDuplicateButNotProcess = 0;
                                        item.Seq = recordSummary.Seq;
                                        //sort again list
                                        foreach (var item1 in listNeedToSort.Where(p => p.Seq >= recordSummary.Seq && p.Id != item.Id).OrderBy(p => p.Seq))
                                        {
                                            item1.Seq += 1;
                                        }
                                        //remove beforeid in listBeforeId
                                        listBeforeId.Remove(item.BeforeId);
                                    }
                                    else
                                    {
                                        //not process
                                        countLoopDuplicateButNotProcess += 1;
                                    }
                                }
                                else
                                {
                                    //reset count loop but it process again
                                    countLoopDuplicateButNotProcess = 0;
                                      //remove beforeid in listBeforeId
                                    listBeforeId.Remove(item.BeforeId);
                                }
                            }
                            else
                            {
                                //not process
                                countLoopDuplicateButNotProcess += 1;
                            }
                        }
                        //break if not process two times.
                        if (countLoopDuplicateButNotProcess == 2)
                        {
                            break;
                        }
                    }
