    public new string Load(string fileName)
    {
        MSProject.ApplicationClass app = null;
        string retVal = "";
        //if the list object hasn't been created yet, then create it now
        if (tasks == null) 
            tasks = new List<MSProject.Task>();
        else //if it was already created, just clear it.
            tasks.Clear();
        try
        {
            //... (I didn't paste all of the code. It is still required, of course.)
                // go through all the open projects--there should only be one
                foreach (MSProject.Project proj in app.Projects)
                {
                    // go through all the tasks in the project
                    foreach (MSProject.Task task in proj.Tasks)
                    {
                        // add Microsoft Project Task to arraylist                          
                        tasks.Add(task); //<-- this was the correct line, uncommented
                    }
            //... (I didn't paste all of the code. It is still required, of course.)
