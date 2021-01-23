    public class StringWrapper
    {
        public string Value
        { get; set; }
        public StringWrapper(string s)
        {
            this.Value = s;
        }
    
        public static implicit operator StringWrapper(string s)
        {
            return new StringWrapper(s);
        }
    }
----------
    public static class Tools
    {
        public static List<StringWrapper> GetImgUrls()
        {
            List<StringWrapper> imgURLS = new List<StringWrapper>();    
    
            String selectExpression = "Select * From Gallery Where Category = 'imgurls'";
            SelectRequest selectRequestAction = new SelectRequest().WithSelectExpression(selectExpression);
            SelectResponse selectResponse = sdb.Select(selectRequestAction);
    
            if (selectResponse.IsSetSelectResult())
            {
                SelectResult selectResult = selectResponse.SelectResult;
                foreach (Item item in selectResult.Item)
                {
                    Console.WriteLine("  Item");
                    if (item.IsSetName())
                    {
                       imgURLS.Add(item.Value)  //the URL of the image
                    }
                }
            }
            return imgURLS;
        }
    }
