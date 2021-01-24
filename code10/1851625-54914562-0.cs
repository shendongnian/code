c#
class MyStock : Stock
{
    protected override void OnPriceChanged (PriceChangedEventArgs e)
    {
        // Do something
        base.OnPriceChanged(e); // will call OnPriceChanged in the base class, and fire the event
    }
}
