       /* Use MyObject like below:
            var b = new MyObject();
            b.datesString = "20190819|20190830|20190915"; //set datesList to list of strings
            var ss = new List<string> { "a", "b" };
            b.datesList = ss; //set datesString to 'a|b'
        */
        public class MyObject {
            public string datesString {get;set;}
            public IEnumerable<string> datesList
            {
                get
                {
                    if(string.IsNullOrEmpty(datesString))
                    {
                        return null;// or new empty list
                    }
                    return datesString.Split('|');
                }
                set
                {
                    if(value != null)
                    {
                        datesString = "";
                        foreach(var s in value)
                        {
                            datesString += s + "|";
                        }
                        datesString = datesString.Substring(0, datesString.Length - 1);
                    }
                }
            }
        }
