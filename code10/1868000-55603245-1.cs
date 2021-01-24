        private void button1_Click(object sender, EventArgs e)
        {
            wfrm.Show(); // make sure you are making the form visible before updating
            Task task = new Task(LeftJoinTables);
            task.Start();
        }
        private void LeftJoinTables()
        {
            wfrm.ProcInfo("test");
        }
