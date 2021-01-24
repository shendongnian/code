    string[] email = Notifications.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
    foreach (var item in Notifications)
                {
                    mail.To.Add((item).ToString());
                }
