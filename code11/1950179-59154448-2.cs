    public Task Main()
    {
    	var result = new Result();
    	return Task.WhenAll(TaskOne(result), TaskTwo(result), TaskThree(result));
    }
        
        private async Task TaskOne(Result result)
        {
        	var contractSchema = await contractSchemaRepository.GetByContractIdAsync(data.Id);
        	//your logic for task1, set related result properties
        }
        
        private async Task TaskTwo(Result result)
        {
        	var sections = await sectionRepository.GetAllByContractIdAsync(id);
        	//your logic for task2, set related result properties
        }
        
        private async Task TaskThree(Result result)
        {
        	var latestContractId = await contractRepository.GetLatestContractIdByFolderIdAsync(data.FolderId.Value);
        	//your logic for Task3, set related result properties
        }
