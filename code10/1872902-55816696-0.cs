        private async Task CheckAndUpdateSms(Context context)
        {
            string lastReadTimeMilliseconds = Application.Current.Properties["LastSmsReadMilliseconds"].ToString();
            ICursor cursor = context.ContentResolver.Query(Telephony.Sms.ContentUri, null, "date > ?", new string[] { lastReadTimeMilliseconds }, null);
            if (cursor != null)
            {
                int totalSMS = cursor.Count;
                if (cursor.MoveToFirst())
                {
                    double maxReceivedTimeMilliseconds = 0;
                    for (int j = 0; j < totalSMS; j++)
                    {
                        double smsReceivedTimeMilliseconds = cursor.GetString(cursor.GetColumnIndexOrThrow(Telephony.TextBasedSmsColumns.Date)).ToProperDouble();
                        string smsReceivedNumber = cursor.GetString(cursor.GetColumnIndexOrThrow(Telephony.TextBasedSmsColumns.Address));
                        int smsType = cursor.GetString(cursor.GetColumnIndexOrThrow(Telephony.TextBasedSmsColumns.Type)).ToProperInt();
                        //you can process this SMS here
						
                        if (maxReceivedTimeMilliseconds < smsReceivedTimeMilliseconds) maxReceivedTimeMilliseconds = smsReceivedTimeMilliseconds;
                        cursor.MoveToNext();
                    }
                    //store the last message read date/time stamp to the application property so that the next time, we can read SMS processed after this date and time stamp. 
                    if (totalSMS > 0)
                    {
                        Application.Current.Properties["LastSmsReadMilliseconds"] = maxReceivedTimeMilliseconds.ToProperString();
                    }
                }
                cursor.Close();
            }
        }
