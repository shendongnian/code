        var request = (HttpWebRequest)WebRequest.Create(address);
        try {
            using (var response = request.GetResponse() as HttpWebResponse) {
                if (request.HaveResponse && response != null) {
                    using (var reader = new StreamReader(response.GetResponseStream())) {
                        string result = reader.ReadToEnd();
                    }
                }
            }
        }
        catch (WebException wex) {
            if (wex.Response != null) {
                using (var errorResponse = (HttpWebResponse)wex.Response) {
                    using (var reader = new StreamReader(errorResponse.GetResponseStream())) {
                        string error = reader.ReadToEnd();
                        //TODO: use JSON.net to parse this string and look at the error message
                    }
                }
            }
        }
    }
