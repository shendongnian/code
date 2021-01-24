csharp
    // Don't do this
    //protected override async Task OnInitializedAsync()
    //{
    //    await LongOperation();
    //}
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            await LongOperation();
            StateHasChanged();
        }
    }
For the OP code:
c#
protected async Task Submit()
{
    //Show Sending...
    cursorCSS = "";
    this.StateHasChanged();
    response = await Task.Run(()=> Service.Post(userModel)); //<--here!
    if (response.Errors.Any())
    {
        errorCss = "errorOn";
    }
    //turn sending off
    cursorCSS = "cursorSpinOff";
    this.StateHasChanged();
}
**Example**
    async Task AsyncLongFunc()    // this is an async task
    {
        spinning=true;
        await Task.Run(()=> LongFunc());  //<--here!
        currentCount++;
        spinning=false;
    }
As you can see, `StateHasChanged` is not needed. 
**Effect:**
[![enter image description here][1]][1]
    @page "/counter"
    
    <h1>Counter</h1>
    
    <p>Current count: 
       @(spinning?"Incrementing .... (the spinning effect)":currentCount.ToString())
    </p>
    
    <button class="btn btn-primary" 
            @onclick="@IncrementCount">Click me</button>
    
    <button class="btn  @(spinning?"btn-dark":"btn-primary") " 
            @onclick="@AsyncLongFunc">Click me Async</button>
    
    @code {                     
        int currentCount = 0;
        bool spinning = false;
        void IncrementCount()
        {
            currentCount++;
        }
    
        async Task AsyncLongFunc()
        {
            spinning=true;
            await Task.Run(()=> LongFunc());  //<--here!
            currentCount++;
            spinning=false;
            await Task.CompletedTask;
        }
    
        void LongFunc() => Task.Delay(2000).Wait();
    }
Learn more about how to write nice spinner you can learn from open source project [BlazorPro.Spinkit][4], it contains clever samples like this one:
c#
async Task TryLoadingData(Action<WeatherForecast[]> onSuccess, 
                          Action<Exception> onFaulted)
{
    isLoading = true;
    try
    {
        if (forceException)
        {
            throw new NotSupportedException();
        }
        var data = await Task.Run(() => WeatherService.GetForecast(DateTime.Now));
        isFaulted = false;
        onSuccess(data);
    }
    catch (Exception e)
    {
        isFaulted = true;
        onFaulted(e);
    }
    finally
    {
        isLoading = false;
    }
}
  [1]: https://i.stack.imgur.com/Xrgnb.gif
  [2]: https://stackoverflow.com/users/757937/ed-charbeneau
  [3]: https://github.com/EdCharbeneau/BlazorPro.Spinkit/
  [4]: https://github.com/EdCharbeneau/BlazorPro.Spinkit/
