private async Task CreateTaskWithTimerAsync( UIImageView seatImageView, CancellationToken ct,string seat )
{
    ChangeImageToLocked(ImageGREEN);
    await Task.Delay( 30000, ct );
    ChangeImageToUnLocked(ImageRED);
}
private void CreateTask(UIImageView _seatIDUIIV, string _seatID)
{
    CancellationTokenSource cts = new CancellationTokenSource();
    deviceDetectedDict.Add(_seatID, cts);
    var _ = CreateTaskWithTimerAsync(_seatIDUIIV, cts.Token, _seatID));
}
