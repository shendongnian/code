    [assembly: Dependency(typeof(Dialer))]
    namespace DialerDemo.Droid
    {
        class Dialer : ICallerDialer
        {
            public string GetCallLogs()
            {
                string queryFilter = String.Format("{0}={1}", CallLog.Calls.Type, (int)CallType.Outgoing);
                string querySorter = String.Format("{0} desc ", CallLog.Calls.Date);
                ICursor queryData1 = Android.App.Application.Context.ContentResolver.Query(CallLog.Calls.ContentUri, null, queryFilter ,null, querySorter);
                int number = queryData1.GetColumnIndex(CallLog.Calls.Number);
                int duration1 = queryData1.GetColumnIndex(CallLog.Calls.Duration);
                if (queryData1.MoveToFirst() == true)
                {
                    String phNumber = queryData1.GetString(number);
                    String callDuration = queryData1.GetString(duration1);
    
                    return callDuration;
                }
                return string.Empty;
            }
        }
    }
