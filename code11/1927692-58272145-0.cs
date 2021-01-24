public override async Task ViewAppearing()
{
    base.ViewAppearing()
    await Task.Delay(2000);
    ...
}
