<local:MasterPage x:Name="masterPage" />
After that, you can use this variable in cs file without new declaration, like this:
public MainPage()
{
    masterPage = new MasterPage(); // already declared in xaml
    Detail = new NavigationPage(new ContactsPage());
    masterPage.ListView.ItemSelected += OnItemSelected;
    // ...
}
