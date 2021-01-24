        public ActionResult Index()
        {
            // Using Neo4j.Driver
            List<Item> items = new List<Item>();
            using (var session = _driver.Session())
            {
                var results = session.ReadTransaction(tx => tx.Run("MATCH (a:Item) RETURN (a)"));
               
                foreach(IRecord result in results)
                {
                    var Node = result["a"].As<INode>();
                    var Id = node.Properties["ID"]?.As<long>();
                    var Name = node.Properties["Name"]?.As<string>();
                    var Type = node.Properties["Type"]?.As<string>();
                    items.Add(new Item { id = Id, name = Name, type = Type });
                }
                return View(items.ToList());               
            }
            
        }
