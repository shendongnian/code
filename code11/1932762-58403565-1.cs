            signer.Tabs = new Tabs
            {
                TextTabs = new List<DocuSign.eSign.Model.Text>
                {
                    bankName,
                    accountName
                },
                NumberTabs = new List<DocuSign.eSign.Model.Number>
                {
                    accountNumber
                }
            };
