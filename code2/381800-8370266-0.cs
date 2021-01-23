            Console.WriteLine("Commencing XML persistency test");
            CedLib.Persistence.XMLPersistenceDictionary.XMLPersistenceDictionary persistence = new CedLib.Persistence.XMLPersistenceDictionary.XMLPersistenceDictionary(logger); //Works!!
            persistence.Add("test", "testvaluefennecs");
            persistence["test"].Add("test", "fennecs");
            Console.WriteLine(persistence["test"].obj);
            foreach (var snode in persistence)
            {
                Console.Write("Contents: " + snode.obj);
                foreach (var item in snode.childnodes)
                {
                    Console.Write("Contents: " + snode.obj);
                }
            }
            Console.WriteLine("\nSaving dictionary");
            persistence.save("test.xml");
            persistence = null; Console.WriteLine("Nullified dictionary");
            persistence = new CedLib.Persistence.XMLPersistenceDictionary.XMLPersistenceDictionary();
            persistence.load("test.xml");
            Console.WriteLine("Loaded dictionary");
            if (persistence["test"].obj != "testvaluefennecs")
            {
                logger.logerror(new Exception("XML test failed!! Expected 'testvaluefennecs', got: " + persistence["test"].obj));
            }
            else
                Console.WriteLine("XML test success!");
            
