    public class AllCommittenteV : CommittenteV, IRepresentAll {}
    Committente.Insert(0, new AllCommittenteV());
    if (SelectedItem is typeof(AllCommittenteV))
       // Use All
    else
       // Use One
