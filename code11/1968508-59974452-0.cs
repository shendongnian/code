    var Groups = conflictsAndSources.GroupBy(x => x.Conflict.FilePath, x => x.Source);
    foreach(var group in Groups)        
    {
         da.FixGroupOfFileConflicts(group.Key, group);
    }
Then the FixGroupOfFileConflicts method signature would be this:
FixGroupOfFileConflicts(string conflictFilePath, IEnumerable<source type here> conflictsOfTheFile);
