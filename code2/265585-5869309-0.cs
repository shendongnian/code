        private void ProcessOrders(List<MyOrder> myOrders)
        {
            lvItems.Items.Clear();
            marketInfo = new MarketInfo();
            ListViewItem[] myItems = new ListViewItem[myOrders.Count];
            string[] mySubItems = new string[8];
            int counter = 0;
            MarketInfo.GetTime();
            CurrentTime = MarketInfo.CurrentTime;
            // ReSharper disable TooWideLocalVariableScope
            DateTime orderIssueDate;
            // ReSharper restore TooWideLocalVariableScope
            foreach (MyOrder myOrder in myOrders)
            {
                string orderIsBuySell = myOrder.IsBuyOrder ? "Buy" : "Sell";
                var listItem = new ListViewItem(orderIsBuySell);
                mySubItems[0] = myOrder.Name;
                mySubItems[1] = string.Format("{0:g}/{1:g}", myOrder.QuantityRemaining, myOrder.InitialQuantity);
                mySubItems[2] = myOrder.Price.ToString("f");
                mySubItems[3] = myOrder.Local;
                if (myOrder.IsBuyOrder)
                    mySubItems[4] = myOrder.Range == -1 ? "Local" : myOrder.Range.ToString("g");
                else
                    mySubItems[4] = "N/A";
                mySubItems[5] = myOrder.MinQuantityToBuy.ToString("g");
                // This code smells:
                string issueDateString = string.Format("{0} {1}", myOrder.DateWhenIssued, myOrder.TimeWhenIssued);
                if (DateTime.TryParse(issueDateString, out orderIssueDate))
                    mySubItems[6] = MarketInfo.ParseTimeData(CurrentTime, orderIssueDate, myOrder.Duration);
                else
                    mySubItems[6] = "Error getting date";
                mySubItems[7] = myOrder.ID.ToString("g");
                listItem.SubItems.AddRange(mySubItems);
                myItems[counter] = listItem;
                counter++;
            }
            lvItems.BeginUpdate();
            lvItems.Items.AddRange(myItems.ToArray());
            lvItems.EndUpdate();
        }
