csharp
//random is seeded based on current time; so best to do it once
Random rnd = new Random();
//the has the extra async keyword
private async void timer1_Tick(object sender, EventArgs e)
{
    //await this call because you need its data
    var data = await ReadDeviceData();
    //set the data; note: use the variable here
    label1.Text = Convert.ToString(data);
}
//signature changed
private async Task<int> ReadDeviceData()
{
    //await a Task.Delay. (Thread.Sleep is thread blocking)
    await Task.Delay(300);//Simulation of long treatment for reading        
    return rnd.Next();            
}
