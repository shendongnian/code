var l = Settings.Default.All
    ? UnitOfWork.Query.Lexis.LexisForApprove2()
    : new List<xxx>();
if (!Settings.Default.All)
{
    if (Settings.Default.MLhuillier)
    {
        l.AddRange(UnitOfWork.Query.Lexis.LexisForApprove2().Where(x => x.ServiceMode == "MLhuillier"));
    }
    if (Settings.Default.BPI)
    {
        l.AddRange(UnitOfWork.Query.Lexis.LexisForApprove2().Where(x => x.ServiceMode == "BPI"));
    }
}
List = new ObservableCollection<LexisNexis>(l.OrderByDescending(x => x.TxnID));
