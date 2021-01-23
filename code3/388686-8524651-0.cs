            var cItems = new System.Collections.Generic.Dictionary<string, DateTime>();
            foreach (SPListItem item in allData)
            {
                string sName;
                DateTime dtDate;
                sName = item.GetFormattedValue("Name");
                dtDate = (DateTime)item.GetFormattedValue("latestDate");
                if (cItems.ContainsKey(sName))
                {
                    // later
                }
                else
                {
                    cItems.Add(sName, dtDate);
                }
            }
