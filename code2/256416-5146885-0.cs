    MyEntities bh = new MyEntities ();
    foreach (var s in bh.TaskGraphs)
    {
        try
        {
            using (var x = new MemoryStream(s.TaskGraph1))
            {
                //var t = TaskGraph.Load(x);
                //Validate(t);
                bn.Detach(t);
            }
        }
        catch (Exception e)
        {                
        }
    }
