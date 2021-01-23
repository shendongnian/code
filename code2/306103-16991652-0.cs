     void connection_OnDisconnect(object sender, SubscriptionErrorEventArgs args)
        {
            var c = (Dictionary<string, StreamingSubscription>)typeof(StreamingSubscriptionConnection).GetField("subscriptions",System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(sender);
            if (c.Count > 0)
            {
                // reopen the connection
                ((StreamingSubscriptionConnection)sender).Open();
                using (var db = new Metrics_DatabaseEntities())
                {
                    PushNotificationTest pt = new PushNotificationTest();
                    pt.RetObj = "Connection reset";
                    db.PushNotificationTests.Add(pt);
                    db.SaveChanges();
                }
            }
            else
            {
                using (var db = new Metrics_DatabaseEntities())
                {
                    PushNotificationTest pt = new PushNotificationTest();
                    pt.RetObj = "Connection closed!";
                    db.PushNotificationTests.Add(pt);
                    db.SaveChanges();
                }
            }
        }
