    var statusRepository = new StatusRepositoryClient.StatusRepositoryClient();
    try
    {
        statusId = statusRepository.GetIdByName(licencePlateSeen.CameraId.ToString());
        statusRepository.Close()
    }
    catch(Exception e)
    {
       statusRepository.Abort();
       LogMessage(e);
       throw; //I would do this to let user know.
    }
