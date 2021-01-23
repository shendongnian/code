      public void Run()
      {
          string fileToLoad = this.GetType().Name + ".xml";
          XElement root = XElement.Load(fileToLoad);
          var selected = from cli in root.Elements("client")
              where cli.Element("ID").Value == "1"
              select cli;
          System.Console.WriteLine("Selected:");
          foreach (var d in selected)
              Console.WriteLine("{0}", d.ToString());
          System.Console.WriteLine("\nitems:");
          foreach (var d in selected)
          {
              Console.WriteLine("id: {0}", d.Element("ID"));
          }
      }
