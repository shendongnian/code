csharp
public class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public override string ToString()
    {
        return "Person";
    }
}
**Template**
xaml
<TabControl ItemsSource="{Binding Items}">
    <TabControl.ItemTemplate>
        <DataTemplate>
            <TextBlock Text="{Binding}"/>
        </DataTemplate>
    </TabControl.ItemTemplate>
</TabControl>
