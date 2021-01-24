    var batches = caseList.GroupBy(x => x.ClientNumber);
    foreach (var batch in batches)
    {
        var clientDbContext = await _clientDbContextFactory.CreateClientDbContext(batch.ClientNumber);
        _clientRepository = new ClientRepository(clientDbContext);
        foreach (var item in batch)
        {
            var updatedCase = /// transform case here
            await _clientRepository.CreateCases(updatedCase);
        }
    }
