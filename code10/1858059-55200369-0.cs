    private async void button1_Click(object sender, EventArgs e)
    {
        // probably add a try/catch here
        PortalMonitoring monitoring = new PortalMonitoring();
        await monitoring.Process(DateTime.Now); //Date as paramater- Default is null
    }
