        public async Task AddAndSaveEventAsync(IntegrationEvent evt)
            {
                await ResilientTransaction.New(_osDataContext).ExecuteAsync(async () =>
                   {
                       await _osDataContext.SaveChangesAsync();
                       await _eventLogService.SaveEventAsync(evt, _osDataContext.Database.CurrentTransaction.GetDbTransaction());
                   });
            }
