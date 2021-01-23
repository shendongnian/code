    private void button1_Click(object sender, EventArgs e)
    {
        GetDataAsync("www.data.com").ContinueWith(result =>
            {
                if (result.Exception != null)
                {
                    MessageBox.Show(this, "Error: {0}" + result.Exception, "Error");
                }
                else
                {
                    foreach (var obj in result.Result)
                    {
                        textBox1.Text += obj.ToString();
                    }
                }
            },
            TaskScheduler.FromCurrentSynchronizationContext()
            );
    }
    Task<IEnumerable<object>> GetDataAsync(string parameters)
    {
        return Task<IEnumerable<object>>.Factory.StartNew(() =>
        {
            Thread.Sleep(500);
          //  throw new ArgumentException("uups");
            // make wcf call here
            return new object[] { "First", "second" };
        });
    }
