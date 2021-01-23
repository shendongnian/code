        internal static void PopulateHistory(DataGridView dgv, Utility util)
        {
            SetDataGridView_History(dgv, util);
        }
        delegate void UpdateDataGridView_History(DataGridView dgv, Utility util);
        static void SetDataGridView_History(DataGridView dgv, Utility util)
        {
            if (dgv.InvokeRequired)
            {
                UpdateDataGridView_History updaterDelegate = new UpdateDataGridView_History(SetDataGridView_History);
                ((Form)util._w).Invoke(updaterDelegate, new object[] { dgv, util });
            }
            else
                //code that utilizes UI thread (long running process in my case)
        }
