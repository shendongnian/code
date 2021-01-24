    public class MySmsProvider : ISmsProvider
    {        
        public IEnumerable<PXFieldState> ExportSettings
        {
            // Implement definition of each setting/parameter and add to settings list
            get
            {
                return new List<PXFieldState>();
            }
        }
        public void LoadSettings(IEnumerable<ISmsProviderSetting> settings)
        {
            // Retrieve value of each setting/parameter and assign to corresponding member variable
        }
        public async Task SendMessageAsync(SendMessageRequest request, CancellationToken cancellation)
        {
            // Implement logic to send SMS
        }
    }
