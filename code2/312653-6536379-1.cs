     foreach (string[] contactData in data)
            {
                ListItem li = new ListItem(contactData[0], contactData[1]);
                ListItem li1 = new ListItem(contactData[0], contactData[1]);
                ListItem li2 = new ListItem(contactData[0], contactData[1]);
                drpDwnLstRegContact.Items.Add(li);
                drpDwnLstTechContact.Items.Add(li1);
                drpDwnLstBillContact.Items.Add(li2);
            }
