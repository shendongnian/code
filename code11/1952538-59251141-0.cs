private void RunBot()
{
    numToBuy = (int)nudNumToBuy.Value;
    for (int i = 0; i < numToBuy; i++)
    {
        while (true)
        {
            Parallel.Invoke(() => AttachAndBuy(), () => BuyOrder());
        }
    }
}
