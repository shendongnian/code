 [Parameter] protected  EventCallback<string>  OnUserNameChanged { get; set; }
This property will contain a delegate to a method defined on the Parent Component. 
2. Define a property and a backing variable in your Child Component:
     
    private string username;
    public string UserName
    {
        get => username;
        set
        {
            username = value;
            // Invoke the delegate passing it the changed value
            OnUserNameChanged?.Invoke(value);
        }
    } 
   3. Define a method in your Parent Component that gets called from the Child Component when the user name is changed:
     public async void UserNameChanged(string username)
        {
           // Gets and consume the user name
        }
  4. This is how your Child Component is used in your Parent Component:
     Note that we assign the method name to the attribute OnUserNameChanged, which is the delegate property in your Child Component 
   
 
   
     <cinput OnUserNameChanged="UserNameChanged" ></cinput>
        <input type="text" bind="@email">
        <input type="button" onclick="@onsubmit">
Hope this helps...
