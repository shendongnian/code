    for (int i = 0; i < list.Count; i++)
    {
        if (Code != null)
        {
            if (list[i].BauTeilId.Equals(Code))
            {
                //First time set new ID = 0
                newID = 0;
                Debug.WriteLine("Keine neue ID " + newID);
            }
            else
            {
                //Second time set newID = 1
                newID = 1;
                Debug.WriteLine("Neue ID " + newID);
                break;
            }
            Debug.WriteLine(list[i].BauTeilId);
        }
    }
    //newID = 1
    ViewBag.newID = newID;
