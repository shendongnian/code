        if (Code != null)
        {
            if count > 0 will return 0 else return 1
            if (list.Where(x => x.BauTeilId.Equals(Code)).Count() > 0)
            {
                
                newID = 0;
                Debug.WriteLine("Keine neue ID " + newID);
            }
            else
            {
                newID = 1;
                Debug.WriteLine("Neue ID " + newID);
                      
             }
            
        }
        //pass value in viewbag
        ViewBag.newID = newID;
