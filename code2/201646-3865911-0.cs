    public void SaveStream(StreamEditModel stream)
    {
        if (!ModelState.IsValid)
        {
            return;
        }
        if (stream.Id == 0)
        {
            CreateStream(stream);
        }
        else
        {
            UpdateStream(stream);
        }
    }
    private void CreateStream(StreamEditModel form)
    {
        var stream = new Stream();
        FillStream(stream, form);
        UpdateStream2FieldTypes(stream, form);
        genesisRepository.SubmitChanges();
    }
    private void UpdateStream(StreamEditModel form)
    {
        var stream = genesisRepository.GetById(stream.StreamID);
        FillStream(stream, form);
        UpdateStream2FieldTypes(stream, form);
        genesisRepository.SubmitChanges();
    }
    private void FillStream(Stream stream, StreamEditModel form)
    {
        stream.StreamUrl = form.StreamUrl;
        stream.StreamName = form.StreamName;
        stream.StreamBody = form.StreamBody;
        stream.StreamTitle = form.StreamTitle;
        stream.StreamKeywords = form.StreamKeywords;
        stream.StreamDescription = form.StreamDescription;
    }
    private void UpdateStream2FieldTypes(Stream stream,
        StreamEditModel form)
    {
        var typesToDelete =
            from type in stream.Stream2FieldTypes
            let ids = form.Stream2FieldTypes.Select(t => t.FieldTypeID)
            where !ids.Contains(type.FieldTypeID)
            select type;
        genesisRepository.RemoveStream2FieldTypes(typesToDelete);
        var typesToAdd =
            from type in form.Stream2FieldTypes
            where type.FieldTypeID == 0
            select CreateStream2FieldTypes(type);
        foreach (var typeToAdd in typesToAdd)
        {
            stream.Stream2FieldTypes.Add(typeToAdd);
        }
        var formTypesToUpdate = 
            from type in form.Stream2FieldTypes
            where type.FieldTypeID != 0
            select type;
        foreach (var modelToUpdate in formTypesToUpdate)
        {
            var typeToUpdate = stream.Stream2FieldTypes.Single(
                t => t.FieldTypeID == modelToUpdate.FieldTypeID);
            FillStream2FieldTypes(typeToUpdate, typeToUpdate);
        }
    }
    private static  Stream2FieldTypes CreateStream2FieldTypes(
        Stream2FieldTypesEditModel form)
    {
        var fieldType = new Stream2FieldTypes();
 
        FillStream2FieldTypes(fieldType, form);
        return fieldType;
    }
    private static void FillStream2FieldTypes(
        Stream2FieldTypes type, 
        Stream2FieldTypesEditModel item)
    {
        type.s2fID = item.s2fID;
        type.s2fIsRequired = item.s2fIsRequired;
        type.s2fLabel = item.s2fLabel;
    }
