    var dtos = query.Select(x => new BankDepositHistoryDTO()
                                 {
                                    AccountId = x.AccountId,
                                    Id = x.Id,
                                    Amount = x.Amount,
                                    AdditionalData = x.AdditionalData,
                                    ClientIp = x.ClientIp,
                                    Gateway = x.Gateway,
                                    PaymentRefNumber = x.PaymentRefNumber,
                                    ReturnUrl = x.ReturnUrl,
                                    State = x.State,
                                    Uuid = x.Uuid
                                 }).ToList();
