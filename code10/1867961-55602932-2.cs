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
This is what Steve Anderson has to say about ref:
**Use case**
The intended use case is to allow parent components to issue commands to child components such as "show" or "reset".
**Even then**, architecturally it's a compromise because it would be cleaner still for your child components to be stateless (that is, not acting on any state other than their parameters) and in that case it's not even theoretically possible for it to make sense to issue an "action" other than by changing their child's parameters, in which case you don't need ref at all.
It is **strongly not recommended** that you use ref as a way of mutating the state of child components. Instead, always use normal declarative parameters to pass data to child components. This will cause child components to re-render at the correct times automatically. We are moving towards changing how parameters on components are represented so that by default they are encapsulated and not possible to read/write from outside.
