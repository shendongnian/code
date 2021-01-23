    public ActionResult RunExperiment(string Title, string Scientist)
    {
        using (RepositoryDataContext RDC = new RepositoryDataContext())
        {
            // Generate the experiment
            Experiment thisExperiment = new Experiment();
            thisExperiment.experimentTitle = Title;
            thisExperiment.experimentScientist = Scientist;
            // Perform some work.
            System.Threading.Thread.Sleep(500);
			
			for (int i = 0; i < 5; i++)
			{
                Result thisResult = new Result();
                thisResult.resultDate = DateTime.Now;
                thisResult.resultTemp = i;
				// LINQ will automatically wire up the association during the insert
				thisExperiment.Results.Add(thisResult);
			}
            // Attempt to insert the experiment, with associated results
            RDC.Experiments.InsertOnSubmit(thisExperiment);
            RDC.SubmitChanges();
        }
        return View("Index");
    }
