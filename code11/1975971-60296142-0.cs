private void button1_Click(object sender, EventArgs e)
{
    //If you need a return result
    //Task.FromResult(MainThread().ConfigureAwait(false)); 
    Task.Run(MainThread);
}
private async Task MainThread()
{
    await Task1().ConfigureAwait(false);
    await Task2().ConfigureAwait(false);
    await Task3().ConfigureAwait(false);
}
private async Task<int> Task1()
{
    await Task.Delay(2000).ConfigureAwait(false);
    Debug.WriteLine("Executed task 1");
    return 1;
}
private async Task<int> Task2()
{
    await Task.Delay(100).ConfigureAwait(false);
    Debug.WriteLine("Executed task 2");
    return 2;
}
private async Task<int> Task3()
{
    await Task.Delay(1000).ConfigureAwait(false);
    Debug.WriteLine("Executed task 3");
    return 3;
}
