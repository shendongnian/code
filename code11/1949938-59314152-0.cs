@page "/"
<input @bind-value="UserInput" @bind-value:event="oninput" @onkeydown="CheckInput"></input>
<h2>My List</h2>
@foreach (var item in myList)
{
    <h3>@item</h3>
}
@code {
    private string UserInput { get; set; }
    public List<string> myList = new List<string> { "ItemOne" };
    private void CheckInput(KeyboardEventArgs keyEvent)
    {
        if(keyEvent.Key == "Enter")
        {
            AddToList(UserInput);
            UserInput = string.Empty;
        }
    }
    private void AddToList(string str)
    {
        myList.Add(str);
    }
}
