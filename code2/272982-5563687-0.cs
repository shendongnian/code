    public static class ThreadingExtensions {
        public static void SyncWithUI(this Control ctl, Action action) {
            ctl.Invoke(action);
        }
    }
    // usage:
    void DoSomething( Form2 frm ) {
        frm.SyncWithUI(()=>frm.Text = "Loading records ...");
    
        // some time-consuming method
        var records = GetDatabaseRecords();
        frm.SyncWithUI(()=> {
            foreach(var record in records) {
                frm.AddRecord(record);
            }
        });
    
        frm.SyncWithUI(()=>frm.Text = "Loading files ...");
        // some other time-consuming method
        var files = GetSomeFiles();
        frm.SyncWithUI(()=>{
            foreach(var file in files) {
                frm.AddFile(file);
            }
        });
    
        frm.SyncWithUI(()=>frm.Text = "Loading is complete.");
    }
