    public void client_OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
    {
        try
        {
            var xml = XDocument.Load(e.Result);
            // get all the result rows from the query (they come as <Result> elements as child elements of <Results> which in turn is a child of <query>)
            var results = from row in xml.Element("query").Element("results").Elements().Where( element => { return (element.Name.LocalName == "Result"); } )
                          select row;
            // now I loop all rows and print the title; of course you can
            // do other stuff here or combine some data processing with the LINQ above
            // - this is up to you
            foreach (var result in results)
            {
                XElement title = result.Elements().Where(element => { return element.Name.LocalName == "Title"; }).FirstOrDefault();
                if (title != null)
                    Debug.WriteLine(title.Value);
            }
        }
        catch (Exception c)
        {
            MessageBox.Show(c.Message);
        }
    }
