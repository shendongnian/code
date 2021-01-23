     private IEnumerable<AsyncOperation> FetchItems(int startId)
     {
         XDocument itemDoc = null;
         int currentId = startId;
         while (currentID != 0)
         {
            yield return DownloadString(new Uri(String.Format("http://SomeURL/{0}.xml", currentId), UriKind.Absolute),
                 itemXml => itemDoc = XDocument.Parse(itemXml) );
            // Do stuff with itemDoc like creating your item and placing it in the list.
            // Assign the next linked ID to currentId or if no other items assign 0
   
         }
     }
