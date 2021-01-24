        public void GetAllContacts()
        {
            List<YourModel> listOfContacts = new List<YourModel();
            string startingUrl = "https://domain.freshdesk.com/api/v2/contacts?per_page=10";
            void GetNext(string url)
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    //reader.ReadToEnd(); // deserialize to model
                    // listOfContacts.Add(<deserialized model>);
                    if (response.Headers["link"] != null) // Check if the header is set on the Response
                        GetNext(response.Headers["link"]); // Header was set, recursive call to the link from the header
                }
            }
            GetNext(startingUrl);
            return listOfContacts;
        }
