        [HttpGet]
        public JsonResult getADEmail(string query = "")
        {
            DirectorySearcher dirSearcher = new DirectorySearcher();
            dirSearcher.Filter = "(&(objectClass=user)(objectcategory=person)(mail=" + query + "*))";
            SearchResult srEmail = dirSearcher.FindOne();
            SearchResultCollection SearchResultCollection = dirSearcher.FindAll();
            string propName = "mail";
            ResultPropertyValueCollection valColl = srEmail.Properties[propName];
                        
            List<string> results = new List<string>();
            foreach (SearchResult sr in SearchResultCollection)
            {
                ResultPropertyValueCollection val = sr.Properties[propName];
                results.Add(val[0].ToString());
            }
            return Json(results);
        }
