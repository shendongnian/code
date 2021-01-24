     public IEnumerable<CallLogModel> GetCallLogs()
        {
            var phoneContacts = new List<CallLogModel>();
            // filter in desc order limit by no
            string querySorter = String.Format("{0} desc ", CallLog.Calls.Date);
            using (var phones = Android.App.Application.Context.ContentResolver.Query(CallLog.Calls.ContentUri, null, null, null, querySorter))
            {
                if (phones != null)
                {
                    while (phones.MoveToNext())
                    {
                        try
                        {
                            string callNumber = phones.GetString(phones.GetColumnIndex(CallLog.Calls.Number));
                            string callDuration = phones.GetString(phones.GetColumnIndex(CallLog.Calls.Duration));
                            long callDate = phones.GetLong(phones.GetColumnIndex(CallLog.Calls.Date));
                            string callName = phones.GetString(phones.GetColumnIndex(CallLog.Calls.CachedName));
                            int callTypeInt = phones.GetInt(phones.GetColumnIndex(CallLog.Calls.Type));
                            string callType = Enum.GetName(typeof(CallType), callTypeInt);                           
                            var log = new CallLogModel();
                            log.CallName = callName;
                            log.CallNumber = callNumber;
                            log.CallDuration = callDuration;
                            log.CallDateTick = callDate;
                            log.CallType = callType;
                            phoneContacts.Add(log);
                        }
                        catch (Exception ex)
                        {
                            //something wrong with one contact, may be display name is completely empty, decide what to do
                        }
                    }
                    phones.Close();
                }
                // if we get here, we can't access the contacts. Consider throwing an exception to display to the user
            }
            return phoneContacts;
        }
