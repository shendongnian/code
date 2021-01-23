    while (listId.Items.Count > 0)
    {
        // making the first item as selected.
        listId.SelectedIndex = 0;
        foreach (object o in listProxy.Items)
        {
            string strProxy = o as string;
            WebProxy proxyObject = new WebProxy(strProxy, true); // insert listProxy proxy here
            WebRequest.DefaultWebProxy = proxyObject;
            string strURL = "http://www.zzzz.com"; // link from listId and insert here
            
            try
            {
                WebRequest req = WebRequest.Create(strURL + "/book.php?qid=" + listId.SelectedItem as string);
                req.Proxy = proxyObject;
                req.Method = "POST";
                req.Timeout = 5000;
            }
            catch (Exception eq)
            {
                string sErr = "Cannot connect to " + strURL + " : " + eq.Message;
                MessageBox.Show(sErr, strURL, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        // remove the selected item.
        listId.Items.RemoveAt(0);
        // refreshing the list.
        listId.Refresh();
    }
