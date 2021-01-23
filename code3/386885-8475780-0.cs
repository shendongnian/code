    public class SurveyData
    {
        public string Name { get; set; }
        public bool Asked { get; set; }
        public DateTime Date { get; set; }
    }
    
    private Dictionary<string, SurveyData>() SurveyInfo = new Dictionary<string, SurveyData>();
    
    public function LoadData()
    {
        // Code to read from disk omitted for brevity. Assume you've parsed
        // the line into 3 variables: name, asked, date.
    
        var item = new SurveyData()
            {
               Name = name,
               Asked = asked,
               Date = date
            };
    
        this.SurveyInfo.Add(item.Name, item);
    }
