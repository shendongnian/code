            Type t = Type.GetTypeFromProgID("Microsoft.Update.Session", "SYDEMMTA001");
            UpdateSession session = (UpdateSession)Activator.CreateInstance(t);
            IUpdateSearcher updateSearcher = session.CreateUpdateSearcher();
            //int count = updateSearcher.GetTotalHistoryCount();
            //IUpdateHistoryEntryCollection history = updateSearcher.QueryHistory(0, count);
            //for (int i = 0; i < count; ++i)
            //{
            //    Console.WriteLine(string.Format("Title: {0}\tSupportURL: {1}\tDate: {2}\tResult Code: {3}\tDescription: {4}\r\n", history[i].Title, history[i].SupportUrl, history[i].Date, history[i].ResultCode, history[i].Description));
            //}
            //Console.WriteLine("Total up: {0}", count);
            ISearchResult sResult = updateSearcher.Search("IsInstalled=0 AND IsPresent=0");
            foreach (IUpdate x in sResult.Updates)
            {
                Console.WriteLine(x.Title);
            }
