    //Define your Graph here - it may be better to use a QueryableGraph if you plan
    //on making lots of Queries against this Graph as that is marginally more performant
    IGraph g = new Graph();
    //Load some data into your Graph using the LoadFromFile() extension method
    g.LoadFromFile("myfile.rdf");
    //Use the extension method ExecuteQuery() to make the query against the Graph
    try
    {
      Object results = g.ExecuteQuery("SELECT * WHERE { ?s a ?type }");
      if (results is SparqlResultSet)
      {
         //SELECT/ASK queries give a SparqlResultSet
         SparqlResultSet rset = (SparqlResultSet)results;
         foreach (SparqlResult r in rset)
         {
           //Do whatever you want with each Result
         }
      } 
      else if (results is IGraph)
      {
         //CONSTRUCT/DESCRIBE queries give a IGraph
         IGraph resGraph = (IGraph)results;
         foreach (Triple t in resGraph.Triples)
         {
            //Do whatever you want with each Triple
         }
      }
      else
      {
         //If you don't get a SparqlResutlSet or IGraph something went wrong 
         //but didn't throw an exception so you should handle it here
         Console.WriteLine("ERROR");
      }
    }
    catch (RdfQueryException queryEx)
    {
       //There was an error executing the query so handle it here
       Console.WriteLine(queryEx.Message);
    }
