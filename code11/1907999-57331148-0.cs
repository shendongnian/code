    string eMailAddress = "someone@sonmewhere.net";
    // Create the data using object literal notation in C#
    object data = new
    {
        name = "value",
        obj = new
        {
            sender_batch_header = new
            {
                email_subject = "You have a payment",
                sender_batch_id = "batch-1564759643870"
            },
            items = new object[]
            {
                new
                {
                    recipient_type = "PHONE",
                    amount = new
                    {
                        value = 1,
                        currency = "USD"
                    },
                    receiver = "4087811638",
                    note = "Payouts sample transaction",
                    sender_item_id = "item-1-1564759643870"
                },
                new
                {
                    recipient_type = "EMAIL",
                    amount = new
                    {
                        value = 1,
                        currency = "USD"
                    },
                    receiver = eMailAddress,
                    note = "Payouts sample transaction",
                    sender_item_id = "item-2-1564759643870"
                }
            }
        }
    };
    // Let .net translate it to json either using JavaScriptSerializer (You have to reference system.web.extensions)
    string json = new JavaScriptSerializer().Serialize(data);
    // or you could use JSON.net from NewtonSoft
    // string json = JsonConvert.SerializeObject(data, Formatting.Indented);
    MessageBox.Show(json);
