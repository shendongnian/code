        bool doStg(DataClassesDataContext db)
        {
            try 
            {
                var results = from t in db.table
                              select t;
                
                //doing some things..
                
                return true;
            }
            catch (Exception Exception)
            {
                MessageBox.Show(Exception.Message);
                return false;
            }
        }
        bool stepByStep() 
        {
            DataClassesDataContext db = new DataClassesDataContext(); 
            Dispatcher.BeginInvoke(new Action(() => info.Text = "Step 1"), null);
            if (!doStg(db)) { return false; }
            Dispatcher.BeginInvoke(new Action(() => progressBar.Value = 33), null);
            Dispatcher.BeginInvoke(new Action(() => info.Text = "Step 2"), null);
            if (!doStg(db)) { return false; }
            Dispatcher.BeginInvoke(new Action(() => progressBar.Value = 66), null);
            Dispatcher.BeginInvoke(new Action(() => info.Text = "Step 3"), null);
            if (!doStg(db)) { return false; }
            Dispatcher.BeginInvoke(new Action(() => progressBar.Value = 100), null);
            
            return true;
        }
