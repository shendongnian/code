    public void Execute(object parameter)
            {
                try
                {
                    var amount = ViewModel.Amount;
                    var transactionId = ViewModel.TransactionMain.TransactionId.ToString();
                    var productCode = ViewModel.TransactionMain.TransactionDetailList.First().Product.ProductCode;
                    var transactionReference = GetToken(amount, transactionId, productCode);
                    var url = string.Format("{0}New?transactionReference={1}", Settings.Default.PaymentUrlWebsite, transactionReference);
                    Process.Start(new ProcessStartInfo(url));
                    ViewModel.UpdateUiWhenDoneWithPayment = new BackgroundWorker {WorkerSupportsCancellation = true};
                    ViewModel.UpdateUiWhenDoneWithPayment.DoWork += ViewModel.updateUiWhenDoneWithPayment_DoWork;
                    ViewModel.UpdateUiWhenDoneWithPayment.RunWorkerCompleted += ViewModel.updateUiWhenDoneWithPayment_RunWorkerCompleted;
                    ViewModel.UpdateUiWhenDoneWithPayment.RunWorkerAsync();
                }
                catch (Exception e)
                {
                    ViewModel.Log.Error("Failed to navigate to payments", e);
                    MessageBox.Show("Failed to navigate to payments");
                }
            }
