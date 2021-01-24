    var paymentIntentService = new PaymentIntentService();
    var paymentIntent = paymentIntentService.Get(transaction.ExternalTransactionId);
        
    if (null != destinationStripeAccount) {
        var options = new PaymentIntentUpdateOptions() {
            TransferData = new PaymentIntentTransferDataOptions {
                Destination = destinationStripeAccount.AccountId
            }
        };
        paymentIntentService.Update(paymentIntent.Id, options);
    }
    
