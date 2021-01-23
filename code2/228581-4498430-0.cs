     set
                {
                    try
                    {
                        _imageTIFF = value;
                    }
                    catch (Exception e)
                    {
                        Logger.log("Can't set image TIFF.", e);
                        throw;
                    }
    
                }
