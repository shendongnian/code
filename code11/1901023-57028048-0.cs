    string searchText = "note";
    List<Process> pfilteredProcess = Process.GetProcesses() // Get All Process
                .Where(p => p.ProcessName.ToLower() // Lower the name case of Process
                .Contains(searchText.ToLower()))   // Lower name of Search text
                .ToList();
    //Work on the Searched List
            foreach (Process process in pfilteredProcess)
            {
                ///Do Activity
            }
           
