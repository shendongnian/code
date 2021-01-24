                        var config = ConfigManager.Instance.GetProperties();
                        config.Add("mode", "live");
                        config.Add("clientId", "get_your_id_from_sandbox");
                        config.Add("clientSecret", "get_your_secret_from_sandbox");
    
                        var accessToken = new OAuthTokenCredential(config).GetAccessToken();
    
                        var apiContext = new APIContext(accessToken);
    
                        apiContext.Config = config;
    
                        // ### Create an invoice
                        // For demonstration purposes, we will create a new invoice for this sample.
                        var invoice = new Invoice()
                        {
                            // #### Merchant Information
                            // Information about the merchant who is sending the invoice.
                            merchant_info = new MerchantInfo()
                            {
                                email = "example@example.com",
                                first_name = "Carl",
                                last_name = "Smithy",
                                business_name = "Buddy Business Inc.",
                                phone = new Phone()
                                {
                                    country_code = "001",
                                    national_number = "1234567890"
                                },
                                address = new InvoiceAddress()
                                {
                                    line1 = "1234 Main St.",
                                    city = "Chicago",
                                    state = "IL",
                                    postal_code = "54321",
                                    country_code = "001"
                                }
                            },
                            // #### Billing Information
                            // Email address of invoice recipient and optional billing information.
                            // > Note: PayPal currently only allows one recipient.
                            billing_info = new List<BillingInfo>()
                    {
                        new BillingInfo()
                        {
                            // **(Required)** Email address of the invoice recipient.
                            email = "example@example.com",
                        }
                    },
                            // #### Invoice Items
                            // List of items to be included in the invoice.
                            // > Note: 100 max per invoice.
                            items = new List<InvoiceItem>()
                    {
                        new InvoiceItem()
                        {
                            name = "Item Name",
                            quantity = 1,
                            unit_price = new Currency()
                            {
                                currency = "USD",
                                value = "6.99" // The Price
                            }
                        }
                    },
                            // #### Invoice Note
                            // Note to the payer. Maximum length is 4000 characters.
                            note = "Payment for <Your Item Here>",
                            // #### Payment Term
                            // **(Optional)** Specifies the payment deadline for the invoice.
                            // > Note: Either `term_type` or `due_date` can be sent, **but not both.**
                            payment_term = new PaymentTerm()
                            {
                                term_type = "NET_30"
                            },
                            // #### Shipping Information
                            // Shipping information for entities to whom items are being shipped.
                            shipping_info = new ShippingInfo()
                            {
                                first_name = "john",
                                last_name = "smith",
                                business_name = "Not applicable",
                                address = new InvoiceAddress()
                                {
                                    line1 = "1234 Main St.",
                                    city = "New York City",
                                    state = "New York",
                                    postal_code = "12345",
                                    country_code = "001",
                                }
                            }
                        };
    
                        var createInvoice = invoice.Create(apiContext);
    
                        createInvoice.Send(apiContext);
                    }
