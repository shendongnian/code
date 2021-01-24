    public async Task<EntityResult<Auto>> Create(NewAuto model) {
        var auto = new Auto {
            Type = model.Type,
            Year = model.Year,
            // other parameters
        };
        try {
            await _autoDb.Create(auto);
            return new EntityResult(auto);
        } catch (Exception e) {
            // return this error object if something broken
            return new EntityResult<Auto>("Error goes here");
        }
    }
