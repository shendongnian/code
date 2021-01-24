c#
new Thread(() =>
{
    while (continue)
    {
        if (xlRange.Cells[i, j].Value2 == null)
            continue = false;
        else
        {
            Invoke(new Action(() =>
            {
                pbar.PerformStep();
            }));
            string key = xlRange.Cells[i, j].Value2.ToString();
            Random r = new Random();
            bool ok = r.Next(100) <= 2 ? false : true;
            if (!ok)
            {
                Invoke(new Action(() =>
                {
                    this.dataGridView1.Rows.Add(x + 1, key);
                }));
                x++;
                Invoke(new Action(() =>
                {
                    groupBox2.Text = "Error (" + x + ")";
                }));
            }
            i++;
        }
    }
}).Start();
This code blocks the exception "Cross-thread operation not valid"
c#
Invoke(new Action(() =>
{
    // Form modification code
}));
