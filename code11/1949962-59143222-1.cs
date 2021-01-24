    var conflictsAndSources = from conflict in OnOffConflictLayers
                              from source in SourceDrawingLayers
                              where conflict.Name == source.Name && conflict.OnOff != source.OnOff
                              select new { Conflict = conflict, Source = source };
    foreach(var conflictAndSource in conflictsAndSources)
        da.FixLayerConflict(conflictAndSource.Conflict.Path, conflictAndSource.Conflict.Name, conflictAndSource.Source.OnOff);
