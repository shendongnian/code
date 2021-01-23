    var parent = Task.Factory.StartNew(() => {
      foreach (var acct in AccountList)
        {
          var currAcctNo = acct.Number;
          Task.Factory.StartNew(() =>
          {
            MyLocalList.AddRange(ProcessThisAccount(currAcctNo));
          }, TaskCreationOptions.AttachedToParent);
          Thread.Sleep(50);
        }
      });
