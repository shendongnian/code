            try
            {
                WebRequest req = HttpWebRequest.Create("http://www.epicurious.com/tools/fooddictionary/entry?id=1650");
                req.Method = "GET";
                string source;
                using (StreamReader reader = new StreamReader(req.GetResponse().GetResponseStream()))
                {
                    source = reader.ReadToEnd();
                }
            }
            catch (Exception exception)
            {
                //Log the exception 
                MessageBox.Show(exception.Message);
            }
