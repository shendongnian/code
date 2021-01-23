    catch (System.Net.WebException ex)
    {
        var errorResponse = (System.Net.HttpWebResponse)ex.Response;
        if (errorResponse.StatusCode == System.Net.HttpStatusCode.Unauthorized)
        {
            //...
        }
    }
