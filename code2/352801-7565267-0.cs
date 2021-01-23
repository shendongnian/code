            var fixedSet = from entry in existing
                           group entry by entry.DocName + entry.Regn into groupedEntries
                           let groupedEntriesAsArray = groupedEntries.ToArray()
                           from groupedEntry in groupedEntriesAsArray
                           let index = Array.IndexOf(groupedEntriesAsArray, groupedEntry)
                           select new Foo
                           {
                               DocName = string.Format("{0}.{1}", groupedEntry.DocName, index + 1),
                               Regn = string.Format("{0}.{1}", groupedEntry.Regn, index + 1)
                           };
