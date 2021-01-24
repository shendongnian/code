    var result = (from paymentTransaction in db.PaymentTransactions
                          join payment in db.Payments on paymentTransaction.PaymentID equals payment.ID
                          where paymentTransaction.TransferStatus == null || (paymentTransaction.TransferStatus != "01" && paymentTransaction.TransferStatus != "02")
                          select new { paymentTransaction, payment }).Union
                         (from paymentTransaction in db.PaymentTransactions
                          join payment in db.Payments on paymentTransaction.TotalGroupID equals payment.TotalGroupID
                          where paymentTransaction.TransferStatus == null || (paymentTransaction.TransferStatus != "01" && paymentTransaction.TransferStatus != "02")
                          select new { paymentTransaction, payment });
            var cartResult = from paymentTransaction in db.PaymentTransactions
                             from payment in db.Payments
                             where paymentTransaction.PaymentID == payment.ID || paymentTransaction.TotalGroupID == payment.TotalGroupID
                             where paymentTransaction.TransferStatus == null || (paymentTransaction.TransferStatus != "01" && paymentTransaction.TransferStatus != "02")
                             select new { paymentTransaction, payment };
