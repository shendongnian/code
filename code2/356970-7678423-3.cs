            using (HttpWebResponse resp = (HttpWebResponse)req.EndGetResponse(aresult))
            using (StreamReader reader = new StreamReader(resp.GetResponseStream()))
            {
                string response = reader.ReadToEnd();
                Debug.WriteLine(response);
                JObject responseJson = JObject.Parse(response);
                ansJson = responseJson;
                Debug.WriteLine("ansJson from responseCallback {0}", ansJson);
            }
