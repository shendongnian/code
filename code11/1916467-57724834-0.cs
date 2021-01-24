       public void AddExternalAccounts(Guid externalId, List<ExternalAccountDto> accounts)
        {
            var entities = _mapper.Map<List<ExternalAccountDto>, List<Account>>(accounts, 
                options => options.AfterMap((source, destination) =>
                    {
                        destination.ForEach(account => account.ExternalId = externalId);
                    }));
        }
