    public ProcessResult DoPandaProcessing()
    {
      using (var file = File.OpenText("filename.txt"))
      {
        while ((line = file.ReadLine()) != null)
        {
           if (line.Contains("Number of files infected"))
           {
              return new ProcessResult { Status = Status.Success, ResultMessage = "Panda " + line };
           }
        }
    
        return new ProcessResult { Status = Status.Failure, ResultMessage = "Panda: No result found!" }
      }
    }
