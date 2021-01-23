     tgdd = new Data();
     context.Datas.InsertOnSubmit(tgdd);
     int count = 0;
     foreach (…)
     {
          count += 1;
          tgd = new Data2();
          tgd.Tgdd = tgdd;
          tgd.count = count;
          context.Datas2.InsertOnSubmit(tgd);  //if this crashes, I want to roll
                                               //back what happened to table 1(Datas)
     }
     context.SubmitChanges();
