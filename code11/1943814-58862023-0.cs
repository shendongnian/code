 csharp
private void Button1_Click(object sender, EventArgs e)
{
    listBox1.Items.Clear();
    Random random = new Random();
    long start = TimeSpan.FromHours(08.20).Ticks;
    long end = TimeSpan.FromHours(08.30).Ticks;
    for (int i = 0; i < 5; ++i)
    {
        long ticks = random.NextLong(start, end);
        TimeSpan t = TimeSpan.FromTicks(ticks);
        listBox1.Items.Add(t);
    }
}
