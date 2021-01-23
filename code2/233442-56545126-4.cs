    List<PaymentSummary> summaries = new List<PaymentSummary>();
    summaries.Add(new xPaymentSummary("My summary is X."));
    summaries.Add(new yPaymentSummary("My summary is Y."));
    summaries.Add(new zPaymentSummary("My summary is Z."));
    foreach (PaymentSummary sum in summaries)
      SerializeRecord(sum);
