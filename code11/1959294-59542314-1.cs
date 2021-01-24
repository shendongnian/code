List<Serials> serials = new List<Serials>
{
    new Serials { Id = 1, Qty = 30, SRNo = "SR-001" },
    new Serials { Id = 2, Qty = 70, SRNo = "SR-002" }
};
decimal? QtyToBeIssued = 50;
foreach (var item in serials)
{
    decimal? ToBeIssued = 0;
    if (QtyToBeIssued > item.Qty)
    {
        ToBeIssued = item.Qty;
    }         
    else // QtyTyBeIssued <= item.Qty
    {
        ToBeIssued = QtyToBeIssued;
    }
    item.Qty = item.Qty - ToBeIssued;
    QtyToBeIssued = QtyToBeIssued - ToBeIssued;
}
Edit: and for shorter code:
foreach (var item in serials)
{
    decimal? ToBeIssued = Math.Min(item.Qty, QtyToBeIssued);
    item.Qty -= ToBeIssued;
    QtyToBeIssued -= ToBeIssued;
}
