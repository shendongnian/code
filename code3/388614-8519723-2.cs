        System.IO.Stream postStream = request._webRequest.EndGetRequestStream(asynchronousResult);
        byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(_postData);                
        postStream.Write(byteArray, 0, byteArray.Length);
        postStream.Close();
        // Start the asynchronous operation to get the response
        request._webRequest.BeginGetResponse(new AsyncCallback(GetResponseCallback), request);
    }
    catch (Exception ex)
    {
        throw ex;
    }
}
