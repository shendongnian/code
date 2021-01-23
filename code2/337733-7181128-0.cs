    using (var ts = new TransactionScope())
    using (DeviceDataContext context = new DeviceDataContext())
    {
       tgdd = new Data();
         context.Datas.InsertOnSubmit(tgdd);
         context.SubmitChanges();
    
         int pk = tgdd.PK;
    
         int count = 0;
         foreach (…)
         {
              count += 1;
              tgd = new Data2();
              tgd.FK = pk;
              tgd.count = count;
              context.Datas2.InsertOnSubmit(tgd);  //if this crashes, I want to roll
                                                   //back what happened to table 1(Datas)
         }
       ts.Complete();
    }
