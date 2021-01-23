    private void Task DoTheWork()
    {
        for(int x = 0; x <= dataGridFollow.Rows.Count - 1; x++) 
        { 
            string getID = dataGridFollow.Rows[x].Cells["ID"].Value.ToString(); 
            int ID = int.Parse(getID); 
            await new Task(UpdateLo); 
        }
    } 
