    var local = ids.GetConsumingEnumerable();
    Task.Factory
            .StartNew(() => {
                foreach (long id in local)
                {
                  //processing code here
                }
            });
