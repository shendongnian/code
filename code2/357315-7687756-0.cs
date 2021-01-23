    catch (WebException ex1)
    {
        using (HttpWebResponse response = (HttpWebResponse) ex1.Response)
        {
            if (response == null)
            {
                // Whatever
            }
            else
            {
                HttpStatusCode status = response.StatusCode;
                // Whatever
            }
        }
    }
