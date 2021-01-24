    private void TaskTest()
    {
        bool appear = false;
        int i = 0;
        while (i < 5)
        {
            i++;
            if (appear == false)
            {
                appear = true;
                Finished_label.Invoke(new MethodInvoker(delegate { Finished_label.Visible = true; }));
            }
            else
            {
                appear = false;
                Finished_label.Invoke(new MethodInvoker(delegate { Finished_label.Visible = false; }));
            }
            System.Threading.Thread.Sleep(1000);
        }
    }
    private void button1_Click(object sender, EventArgs e)
    {
        Task task = Task.Run(() => TaskTest());
    }
