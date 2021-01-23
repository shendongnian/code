        class AutoCompleteEnry
        {
            public int id { get; set; }
            public string label { get; set; }
            public string value { get; set; }
        }
        private void GetAutoCompleteTerms()
        {
            Response.Clear();
            Response.ContentType = "application/json";
            //evaluate input parameters of jquery request here
             List<AutocompleteEnry> autoCompleteList= new List<AutoCompleteEntry>();
            //populate List of AutocompleteEnry here accordingly
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            string json = jsSerializer.Serialize(autoCompleteList);
            Response.Write(json);
            Response.End();
        }
