    [TestFixture]
    public sealed class TestRecursiveDataHandling
    {
        private IList<Path> _pathList;
        [SetUp]
        public void SetUp()
        {
            _pathList = new List<Path>();
        }
        [TearDown]
        public void TearDown()
        {
            _pathList = null; 
        }
        [Test]
        public void CreateLists()
        {
            //Create the data source 
            IList<SourceRow> jpSource = new List<SourceRow>();
            jpSource.Add(new SourceRow("1", 1, new DateTime(2000, 1, 1), new DateTime(2009, 12, 31)));
            jpSource.Add(new SourceRow("2A", 2, new DateTime(2000, 1, 1), new DateTime(2004, 12, 31)));
            jpSource.Add(new SourceRow("2B", 2, new DateTime(2005, 1, 1), new DateTime(2009, 12, 31)));
            jpSource.Add(new SourceRow("3", 3, new DateTime(2000, 1, 1), new DateTime(2009, 12, 31)));
            jpSource.Add(new SourceRow("4A", 4, new DateTime(2000, 1, 1), new DateTime(2008, 12, 31)));
            jpSource.Add(new SourceRow("4B", 4, new DateTime(2009, 1, 1), new DateTime(2009, 12, 31)));
            //Instantiate handler
            TreeHandler handler = new TreeHandler(CreatePathFromButtonNode);
            
            //Handle root node, and recurse 
            handler.HandleNode(jpSource, 0, null, Period.Infinite);
            //DISPLAY TREE PATHS IN CONSOLE 
            DisplayResultInConsole();
            //A simple assertion. Expect that 3 paths were created.
            Assert.That(_pathList.Count, Is.EqualTo(3));
        }
        private void DisplayResultInConsole()
        {
            for (int i = 0; i < _pathList.Count;  i++ )
            {
                IList<Stop> jpList = _pathList[i].Stops;
                string stopList = string.Empty; 
                foreach (Stop stop in jpList)
                {
                    stopList = stopList + stop.ID + ";" + stop.Description + ";"+ stop.Period + " \n";
                }
                string p = "List " + i + ">> Period " + _pathList[i].Period;
                Console.WriteLine("List " + i + ">> Period " +  p);
                Console.WriteLine("Stops: ");
                Console.WriteLine(stopList);
                Console.WriteLine();
            }
        }
        
        //Method for receiving paths from leaf nodes. Passed as delegate to TreeHandler
        private void CreatePathFromButtonNode(JPTreeNode treeNode, Period periodInCommon)
        {
            IList<Stop> stopList = new List<Stop>();
            JPTreeNode currentNode = treeNode; 
            while (currentNode!= null)
            {
                stopList.Add(currentNode.NodeValue);
                currentNode = currentNode.ParentNode; 
            }
             _pathList.Add(new Path(periodInCommon, stopList));
        }
 
    }
