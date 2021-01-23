        void ReadCallback(IAsyncResult result)
        {
                HttpWebRequest req = (HttpWebRequest)result.AsyncState;
                HttpWebResponse responce = (HttpWebResponse)req.EndGetResponse(result);
                Stream s = responce.GetResponseStream();
                StreamReader str = new StreamReader(responce.GetResponseStream());
                {
                    nowparsingstring = str.ReadToEnd();
                }
        }
