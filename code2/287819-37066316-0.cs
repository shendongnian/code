    Using ctx = New AtlasEntities
        modelDefinition = Await ctx.ModelDefinitions.First(Function(f) f.Id=Id)
    End Using
    ModelResult = modelDefinition.DoSomeWork()
    Using ctx As New AtlasEntities
        ctx.ModelDefinitions.Attach(modelDefinition)
        ctx.ModelResults.Add(ModelResult)
        Dim success = Await ctx.SaveChangesQuickly.ConfigureAwait(False)
    End Using
