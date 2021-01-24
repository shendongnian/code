csharp
private void Btn_Actualizar_Click(object sender, EventArgs e)
    {
        OpenFileDialog theDialog = new OpenFileDialog();
        if (theDialog.ShowDialog() == DialogResult.OK)
        {
            string fileName = theDialog.FileName.ToString();
            Load(fileName);
        }
    }
    public new string Load(string fileName)
    {
        MSProject.ApplicationClass app = null;
        string retVal = "";
        List<MSProject.Task> tasks = new List<MSProject.Task>();
        try
        {
            // execute the Microsoft Project Application
            app = new MSProject.ApplicationClass();
            // Do not display Microsoft Project
            app.Visible = false;
            // open the project file.
            if (app.FileOpen(fileName, true, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, MSProject.PjPoolOpen.pjPoolReadOnly, Type.Missing, Type.Missing, Type.Missing, Type.Missing))
            {
                // go through all the open projects--there should only be one
                foreach (MSProject.Project proj in app.Projects)
                {
                    // go through all the tasks in the project
                    foreach (MSProject.Task task in proj.Tasks)
                    {
                        // add Microsoft Project Task to arraylist                          
                        //tasks.Add(new Task(task));
                        tasks.Add(task);
                        //List<Task> tasks1 = new List<Task>();
                    }
                }
            }
            else
            {
                retVal = "The MS Project file " + fileName + " could not be opened.";
            }
        }
        catch (Exception ex)
        {
            retVal = "Could not process the MS Project file " + fileName + "." + System.Environment.NewLine + ex.Message + System.Environment.NewLine + ex.StackTrace;
        }
        // close the application if is was opened.
        if (app != null)
        {
            app.Quit(MSProject.PjSaveType.pjDoNotSave);
        }
        return retVal;
    }
