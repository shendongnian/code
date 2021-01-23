     public class Job : IDataErrorInfo
        {
            public string Title { get; set; }
            public DateTime? Start { get; set; }
            public DateTime? End { get; set; }
    
            public string Error
            {
                get { throw new NotImplementedException(); }
            }
    
            public string this[string columnName]
            {
                get
            {
                string result = null;
                if (columnName == "Title")
                {
                    if (string.IsNullOrEmpty(Title))
                        result = "Please enter a Title ";
                }
                if (columnName == "Start")
                {
                    if (Start == null)
                        result = "Please enter a Start Date";
                    else if (Start > End)
                    {
                        result = "Start Date must be less than end date";
                    }
                }
                return result;
            }
            }
        }
