    //Somewhere in the UI Thread
    Thread worker = new Thread(new ParameterizedThreadStart(UpdateLoWorker));
    worker.Start(dataGridFollow.Rows);
    
    //worker thread
    private void UpdateLoWorker(DataRowCollection rows)
    {
       foreach(DataRow r in rows){
          string getID = r.Cells["ID"].Value.ToString();
          int ID = int.Parse(getID);
          UpdateLo(ID);
       }
    }
