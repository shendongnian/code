            while(count>0)
            {
                HttpQueueItem item = queue[0];
                /// If post succeeded..
                if (snd.IsNotExceedsAcceptedLeadsPerDayLimit(item.DataSaleID, item.AcceptedLeadsPerDayLimit) && snd.PostRecord(item.DataSaleDetailID, item.PostString, item.duplicateCheckHours, item.Username, item.Password, item.successRegex))
                {
                    if (item.WaitTime > 0)
                        Thread.Sleep(item.WaitTime);
                    queue.Remove(item);
                }
                    ///If Exceeds Accepted leads per day limit by DataSale..
                else if (!snd.IsNotExceedsAcceptedLeadsPerDayLimit(item.DataSaleID, item.AcceptedLeadsPerDayLimit))
                {
                    queue.RemoveAll(obj => obj.DataSaleID == item.DataSaleID);
                }
                    /// If Post failed..
                else //if (!snd.PostRecord(item.DataSaleDetailID, item.PostString, item.duplicateCheckHours, item.Username, item.Password, item.successRegex))
                {
                    queue.Remove(item);
                }
                count = queue.Count;
            }
