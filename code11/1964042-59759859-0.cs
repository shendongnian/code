<Editor x:Name = "editor" Placeholder="Enter text here" AutoSize="TextChanges"/>
Pass the editor's text to the Page1 constructor:
private async void NavigateButton_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Page1(editor.Text));
        }
In your Page1 constructor you receive the input as:
public partial class Page1 : ContentPage
{
    public Page1(string editorText)
    {
        InitializeComponent();
        // use editorText
    ...
