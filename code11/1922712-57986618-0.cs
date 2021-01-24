    var isValid = requestList
              .Select(r => 
              {
                  var valid =r.ChannelId.HasValue && r.PayoutAmountInCents.HasValue;
                  if (!valid)
                  {
                      PayoutFDEvents.LogInvalidPayoutRequest(
                          this.BuildPayoutFDDocument(req), "missing channelId or patronage amount");
                  }
                  return valid;
              })
              .DefaultIfEmpty(true)
              .Min();
