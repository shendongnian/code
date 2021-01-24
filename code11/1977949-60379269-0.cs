    public async void ConfRelais()
    {
        var controller = await this.ShowProgressAsync("hey", "hoy");
        controller.Maximum = 128;
        await Task.Run(() =>
        {
            while (flag == 0)
            {
                string data = RelayBoard_Port.ReadTo("\r\n");
                if (data == "ok")
                {
                    controller.SetMessage("Done Process");
                    flag = 1;
                }
                else { controller.SetProgress(Int32.Parse(data)); }
            }
        });
        await controller.CloseAsync();
    }
