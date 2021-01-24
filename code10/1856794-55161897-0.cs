    protected override void OnStop()
    {
        if (_stopping) return;
        try
        {
            _stopping = true;
            _shutdownEvent.Set();
            Thread.Sleep(500);
            _writeFile.Log("O serviço foi parado");
            base.OnStop();
        }
        catch (Exception e)
        {
            _writeFile.Log("Falha ao parar o serviço " + e.Message);
        }
        finally
        {
            _stopping = false;
        }
    }
