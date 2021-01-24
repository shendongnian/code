    public ItemDTO ToDTO()
    {
        return new ItemDTO
        {
            Vid = Vid,
            PortalId = PortalId,
            IsContact = IsContact,
            ProfileUrl = ProfileUrl,
            Properties = 
                Properties.ToDictionary(
                    p => p.Key, 
                    p => p.Value["value"]
                )
        };
    }
