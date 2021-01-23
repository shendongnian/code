      var data = (from item in xel.DescendantsAndSelf("game")
                select new{
                           name = item.Element("name").Value,
                           behaviorlist = item.Element("behaviours-used")
                          }
                ).Single();
       //data.Dump();
    
      var bq = (from c in data.behaviorlist.Descendants("behaviour")
                select new {
                             behaviour = c.Value,
                             id = c.Attribute("id").Value,
                             version = c.Attribute("version").Value
                            });
      //bq.Dump();
