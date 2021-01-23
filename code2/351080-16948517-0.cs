    using (var thisWeb = featSite.OpenWeb(featWeb.ID))
            {
                try
                {
                    var listUpdate = false;
                    var theList = thisWeb.Lists[att.Value];
     
                    // change list configuration
                    // .....
     
                    // commit List modifications
                    if (listUpate)
                        theList.Update();
                }
                catch
                {
                    // log the event and rethrow
                    throw;
                }
            }
        }
    }
