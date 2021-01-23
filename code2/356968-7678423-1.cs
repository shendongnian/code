            using (Stream postStream = req.EndGetRequestStream(aresult))
            {
                string obj = "{ 'username': 'test_2@aragast.com', 'password': 'a123456' }";
                JObject json = JObject.Parse(obj);
                string s = JsonConvert.SerializeObject(json);
                byte[] postdata = System.Text.Encoding.Unicode.GetBytes(s);
                postStream.Write(postdata, 0, postdata.Length);
            }
