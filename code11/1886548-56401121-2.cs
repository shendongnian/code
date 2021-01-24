    var tasksInBatch = new List<Task>();
    foreach (var item in batch)
    {
        var updatedCase = /// transform case here
        tasksInBatch.Add(_clientRepository.CreateCases(updatedCase));
    }
    await Task.WhenAll(tasksInBatch);
