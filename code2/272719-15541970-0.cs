        public static void SetIgnoreRemoteRequests(WebBrowser bro, bool value)
        {
            if (bro.Document is Workbook)
            {
                ((Workbook)bro.Document).Application.IgnoreRemoteRequests = value;
            }
        }
