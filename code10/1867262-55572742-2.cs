     public static List<BankDepositHistoryVM> GetAllByPagination(int page ,int stepes)
        {
            page=page-1;
            using(MyketAdsEntities context = new MyketAdsEntities())
            {
                var transactionlist = context.BankDepositHistories.ToList();
                var start = page * stepes;
              var result=  context.BankDepositHistories.OrderByDescending(c=>c.AccountId)
                    .Skip(start)
                    .Take(stepes)
                    .ToList();
      List<BankDepositHistoryVM> resultVM = new List<BankDepositHistoryVM>();
      resultVM.bankDetails = result;
      resultVM.Count = result.Count();
                return resultVM;
            }
        }
