    class Program
        {   
            static void Main(string[] args)
            {
              string xml = @"<Woods><Wood><ID>1</ID><Name>Hickory</Name><Weight>3</Weight><Thickness>4</Thickness><Density>5</Density><Purity>6</Purity><Age>7</Age></Wood><Wood><ID>2</ID><Name>Soft Maple</Name><Weight>3</Weight><Thickness>4</Thickness><Density>5</Density><Purity>6</Purity><Age>7</Age></Wood><Wood><ID>3</ID><Name>Red Oak</Name><Weight>3</Weight><Thickness>4</Thickness><Density>5</Density><Purity>6</Purity><Age>7</Age></Wood></Woods>";
    
               XDocument doc = XDocument.Parse(xml);
               //Get your wood nodes and values in a list 
               List<Tuple<string,string>> list = doc.Descendants().Select(a=> new Tuple<string,string>(a.Name.LocalName,a.Value)).ToList();
    
               // display the list
               list.All(a => { Console.WriteLine(string.Format("Node name {0} , Node Value {1}", a.Item1, a.Item2)); return true; });
               Console.Read();
            }
        }  
  
