    public async Task PatchPerson(string id)
    {
        await Initialize();
        var person = await GetPerson(id);
        person.Age += 1;
        await personTable.UpdateAsync(person);
        await SyncPeople();
    }
