    var statusRepository = new StatusRepositoryClient.StatusRepositoryClient();
    try
    {
        statusId = statusRepository.GetIdByName(licencePlateSeen.CameraId.ToString());
        statusRepository.Close()
         
    }
    catch (TimeoutException timeout)
    {
      statusRepository.Abort();
      LogMessage(timeout);
      throw; //I would do this to let user know.
    }
    catch (CommunicationException comm)
    {
       statusRepository.Abort();
       LogMessage(comm);
       throw; //I would do this to let user know.
    }
