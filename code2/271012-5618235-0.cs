            while (IsStatusUpdateRunnig)
            {
                ContactData[] contacts = ((ContactData[])View.SourceCollection);//MyListBox.ItemsSource);
                XDocument doc = XDocument.Load("http://localhost/contact/xml/status.php");
                foreach (XElement node in doc.Descendants("update"))
                {
                    ContactData[] its = contacts.Where(i => i.UserID.ToString() == node.Element("UserID").Value).ToArray();
                    if (its.Length > 0)
                    {
                        its[0].UpdateFromXML(node);
                        Dispatcher.Invoke(new Action(() => { View.EditItem(its[0]); }));
                    }
                }
                Dispatcher.Invoke(new Action(() => { View.CommitEdit(); }));
                System.Threading.Thread.Sleep(2000);
            }
