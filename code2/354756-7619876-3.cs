    public SaveResult SaveData(Stream stream)
    {
        SaveResult saveResult = new SaveResult();
        string error = "";
        try
        {
            //do saving data
            saveResult.Success = true;
        }
        catch (Exception ex)
        {
            saveResult.ErrorInfo = new ErrorInfo { Message = ex.Message };
        }
    }
