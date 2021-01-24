     protected void Page_Load(object sender, EventArgs e)
            {
     // Set your secret key: remember to change this to your live secret key in production
                // See your keys here: https://dashboard.stripe.com/account/apikeys
                StripeConfiguration.ApiKey = WebConfigurationManager.AppSettings["StripeSecretKey"];
    
    
    
                var options = new SessionCreateOptions
                {
                    CustomerEmail = "mehdizerouali@hotmail.com",
                    PaymentMethodTypes = new List<string> {
                                        "card",
                                    },
                    LineItems = new List<SessionLineItemOptions> {
                                        new SessionLineItemOptions {
                                            Name = "BPENLIGNE",
                                            Description = "Formule Smart",
                                            Amount = 99,
                                            Currency = "eur",
                                            Quantity = 1,
                                        },
                                    },
                    SuccessUrl = "https://example.com/success?session_id={CHECKOUT_SESSION_ID}",
                    CancelUrl = "https://example.com/cancel",
                };
    
                var service = new SessionService();
                Session session = service.Create(options);
    
                sessionid = session.Id;
            }
