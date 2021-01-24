     public async Task<ObservableCollection<EventsDTO>> GetEvents(bool ShowInActive)
        {
            try
            {
                CheckCredentials.CheckValidCredentials();
                using (var db = new BuxtedAPI(CheckCredentials.RestCredentials))
                {
                    db.HttpClient.DefaultRequestHeaders.Add("X-Version", "2.0");
                    var res = await db.GetEventsAsync(ShowInActive).ConfigureAwait(false);
                    var obs = new ObservableCollection<EventsDTO>(res);
                    return obs;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                MessageBox.Show(
                    $"{ex.Message}{Environment.NewLine}{ex.InnerException?.ToString() ?? ""}");
                return null;
            }
        }
