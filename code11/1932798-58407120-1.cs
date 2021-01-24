    async Task InvokeKmShutdown()
        {
            ...other sync code...
            await KMApplication.ApiService.Disconnect();
            //Check for floating licensing
            if (KMApplication.License != null && KMApplication.License.Scope != License.Core.Enums.LicenseScope.Standalone)
            {
                for (int i = 0; i < 3; i++)
                {
                    try
                    {
                        await KMApplication.License.ShutDown(KMApplication.Settings == null
                                                                 ? Enums.LicenseReturnModes.PromptOnShutdown
                                                                 : KMApplication.Settings.LicenseReturnMode);
                        break;
                    }
                    catch (Exception ex)
                    {
                        _logger.Warn("Exception in license release, attempt " + i, ex);
                    }
                }
            }
        }
