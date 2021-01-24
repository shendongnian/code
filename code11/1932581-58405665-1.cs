      private async void InitializeSignalR()
        {
            try
            {
                connection = new HubConnectionBuilder()
                            .WithUrl("http://localhost:33300/MyHub")
                            .Build();
                #region snippet_ClosedRestart
                connection.Closed += async (error) =>
                {
                    await Task.Delay(new Random().Next(0, 5) * 1000);
                    await connection.StartAsync();
                };
                #endregion
                #region snippet_ConnectionOn
               connection.On<string>("sendmessage", (message) =>
               {
                   this.Dispatcher.Invoke(() =>
                   {
                       lstListBox.Items.Add(message);
                   });
               });
                #endregion
                try
                {
                    await connection.StartAsync();
                    lstListBox.Items.Add("Connection started");
                    //connectButton.IsEnabled = false;
                    btnSend.IsEnabled = true;
                }
                catch (Exception ex)
                {
                    lstListBox.Items.Add(ex.Message);
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
