    if (service.Status == ServiceControllerStatus.Stopped)
            {
                try
                {
                    service.Start();
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
            }
            else
            {
                try
                {
                    service.Stop();
                    service.Start();
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
            }
