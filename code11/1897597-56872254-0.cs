public class LogEntryList
{
    public List<LogEntry> LogEntries { get; set; }
    public LogEntryList() { LogEntries = new List<LogEntry>(); }
}
public class LogEntry
{
    public string Name { get; set; }
    public string Data { get; set; }
    public Brush BgColor { get; set; }
    public bool Selected { get; set; }
    public double Type { get; set; }
}
DataContext = logEntryList;
logEntryList.LogEntries.Add(new LogEntry { Name = "Exception 2", Type = 02 });
logEntryList.LogEntries.Add(new LogEntry { Name = "Exception 7", Type = 07 });
<ListBox Grid.Row="1" Background="DarkGray" ItemsSource="{Binding LogEntries}">
    <ListBox.ItemTemplate>
        <DataTemplate>
            <StackPanel Orientation="Horizontal">
                <TextBlock VerticalAlignment="Center" Background="Purple">Name:</TextBlock>
                <TextBlock VerticalAlignment="Center" Margin="5" Text="{Binding Name}" />
                <TextBlock VerticalAlignment="Center" Background="Purple">Name:</TextBlock>
                <TextBlock VerticalAlignment="Center" Margin="5" Text="{Binding Type}" />
            </StackPanel>
        </DataTemplate>
    </ListBox.ItemTemplate>
</ListBox>
