        var t = new Task(() =>
        {
            var server = MongoServer.Create();
            //server.RunAdminCommand("shutdown"); -- throws exception
            server.Shutdown();
        });
        t.Start();
        try
        {
            t.Wait(5000);
        }
        catch (EndOfStreamException e)
        {
            // silently ignore
        }
        finally
        {
            if (!_mongoProcess.HasExited)
            {
                _mongoProcess.Kill();
            }
        }
