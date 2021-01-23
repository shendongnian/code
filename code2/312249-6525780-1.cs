        int KeyCount = page.Request.Form.AllKeys.Length;
        for (int i = 0; i < KeyCount; i++)
        {
            if (page.Request.Form.AllKeys[i] == "Thread1")
            {
                return page.FindControl("Thread1");
            }
            if (page.Request.Form.AllKeys[i] == "Thread2")
            {
                return page.FindControl("Thread2");
            }
        }
