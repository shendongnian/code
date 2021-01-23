    Public class FooBar
    {
       private ManualResetEvent _completedEvent = new ManualResetEvent(false);
       List<Items> _items = new List<Items>();
    
       public List<Items> FetchItems(int parentItemId)
       {
          FetchSingleItem(itemId);
          _completedEvent.WaitOne();
          return _items
       }
    
       private void FetchSingleItem(int itemId)
       {
           Uri url = new Uri(String.Format("http://SomeURL/{0}.xml", itemId);
           HttpWebRequest webRequest = (HttpWebRequest)HttpWebRequest.Create(url);
    
           webRequest.BeginGetResponse(ReceiveResponseCallback, webRequest);
       }
    
       void ReceiveResponseCallback(IAsyncResult result)
       {
            // End the call and extract the XML from the response and add item to list
    
            _items.Add(itemFromXMLResponse);
    
            // If this item is linked to another item then fetch that item 
    
    
            if (anotherItemIdExists == true)
            {
                FetchSingleItem(anotherItemId);
            }
            else
                _completedEvent.Set();
       }
    }
