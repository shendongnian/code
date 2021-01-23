    XElement xmlTweets = XElement.Parse(e.Result);
    var id = 4001;   // the ID to find
    var toto = from tweet in xmlTweets.Descendants("MyItem")
                                      .Take(10)
               orderby (DateTime)tweet.Element("TimeStamp")
                                      .Attribute("ComputerTime") descending
               select new History {
                   DisplayName = String.Format("{0} {1}",
                       tweet.Attribute("PatientFirstName").Value,
                       tweet.Attribute("PatientLastName").Value),
                   // find the Variable with matching ID and get its Value as a double
                   Value = (from v in tweet.Descendants("Variable")
                            where (int)v.Attribute("ID") == id
                            select (double)v.Attribute("Value"))
                           .Single()
               };
