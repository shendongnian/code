C#
public class Question
{
    public int ID { get; set; }
    public string Text { get; set; }
    public bool IsSelected { get; set; }
}
Here's your ListView. We bind CheckBox.IsSelected to ListViewItem.IsSelected, so the user can check them just by clicking anywhere on the item. Then we bind Question.IsSelected to ListViewItem.IsSelected in an ItemContainerStyle. 
XAML
<ListView 
    x:Name="listview" 
    Background="Azure" 
    SelectionMode="Multiple"
    ItemsSource="{Binding Questions}" 
    >
    <ListView.ItemTemplate>
        <DataTemplate>
            <CheckBox 
                IsChecked="{Binding RelativeSource={RelativeSource AncestorType=ListViewItem}, Path=IsSelected}"
                Content="{Binding Text}" Margin="0,5,0,0"
                />
        </DataTemplate>
    </ListView.ItemTemplate>
    <ListView.ItemContainerStyle>
        <Style TargetType="ListViewItem">
            <Setter Property="IsSelected" Value="{Binding IsSelected}" />
        </Style>
    </ListView.ItemContainerStyle>
</ListView>
And here's how we do stuff with the selected questions in that event handler. I'm guessing that your `Strings` collection was a member of the Window or whatever view you have; let me know if that's not the case and we'll figure out how to get to it. Remember, we're calling that collection `Questions` now. 
C#
private void AddToSurvey_Click(object sender, RoutedEventArgs e)
{
    string allQuestionsText = "";
    foreach (var question in Questions.Where(q => q.IsSelected))
    {
        //  I don't know what you really want to do in here. 
        allQuestionsText += question.Text + "\n";
    }
}
