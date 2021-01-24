        static void Main(string[] args)
        {
            try
            {
                // Authenticate with PayPal
                var config = ConfigManager.Instance.GetProperties();
                var accessToken = new OAuthTokenCredential(config).GetAccessToken();
                var apiContext = new APIContext(accessToken);
                var payout = Payout.Create(apiContext, new Payout
                {
                    sender_batch_header = new PayoutSenderBatchHeader
                    {
                        email_subject = "Hello payout",
                        sender_batch_id = "ilab_Payout002",
                        recipient_type = PayoutRecipientType.EMAIL
                    },
                    items = new List<PayoutItem>
                    {
                        new PayoutItem
                        {
                            amount = new Currency
                            {
                                currency = "USD",
                                value = "17.5"
                            },
                            note = "Exchange is done!",
                            receiver = "ilab-test1@gmail.com",
                            recipient_type = PayoutRecipientType.EMAIL,
                            sender_item_id = "121341"
                        }
                    },
                });
            }
            catch (PaymentsException e)
            {
                Console.WriteLine(e.Response);
            }
        }
    }
