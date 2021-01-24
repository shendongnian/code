    private async void button2_Click(object sender, EventArgs e)
    {
        string url = "https://idscheckingsite.com";
        const int WORKER_TASKS_COUNT = 4;
        var workerTasks = new Task[WORKER_TASKS_COUNT];
        for (int i = 0; i < WORKER_TASKS_COUNT; i++)
        {
            workerTasks[i] = DoWorkAsync(i);
        }
        Task.WaitAll(workerTasks);
        dataGridView1.DataSource = dt;
        async Task DoWorkAsync(int workerIndex)
        {
            using (var wb = new WebBrowser())
            {
                wb.ScriptErrorsSuppressed = true;
                for (int i = 0; i < ListsofIds.Length; i++)
                {
                    if (i % WORKER_TASKS_COUNT != workerIndex) continue;
                    wb.Navigate(url);
                    await wb; // await for the next DocumentCompleted
                    wb.Document.GetElementById("pannumber").InnerText = ListsofIds[i];
                    wb.Document.GetElementById("frmType1").SetAttribute("value", "24Q");
                    HtmlElement btnlink = wb.Document.GetElementById("clickGo1");
                    btnlink.InvokeMember("Click");
                    await wb; // await for the next DocumentCompleted
                    string status = wb.Document.GetElementById("status").InnerText;
                    string name = wb.Document.GetElementById("name").InnerText;
                    DataRow dr = dt.NewRow();
                    dr[0] = PANNumber[i];
                    dr[1] = status;
                    dr[2] = name;
                    dt.Rows.Add(dr);
                }
            }
        }
    }
