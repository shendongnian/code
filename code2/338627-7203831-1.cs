     public void Fill_WF_Doc(string ID, int doc)
        {
            DataClasses1DataContext DB = new DataClasses1DataContext();
            Waiting_Task entry = new Waiting_Task();
            var c = from D in DB.Waiting_Tasks
                    where (D.WF_ID == ID)
                    select D.Doc_ID;
            c = doc;//this throw an exception as doc is an Int but c is an ienumerable
    
         }
