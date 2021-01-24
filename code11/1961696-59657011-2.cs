    @model YSMadmin.Models.ResultsViewModel
    ...
        @(Html
              .Grid(Model.PaymentHistory)
              .Build(columns =>
              {
                  columns.Add(model => model.TransactionCode).Titled("Transaction Code");
                  columns.Add(model => model.TransactionType).Titled("Transaction Type");
                  columns.Add(model => model.TransactionDate).Titled("Transaction Date").Formatted("{0:d}");
                  columns.Add(model => model.EffectiveDate).Titled("Effective Date").Formatted("{0:d}");
                  columns.Add(model => model.TransactionAmount).Titled("Transaction Amount");
              })
              .Empty("No data found")
              .Pageable()
              )
