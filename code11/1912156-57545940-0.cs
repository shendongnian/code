<input type="text" @bind-value="Data" @bind-value:event="oninput" 
       @onkeyup="@HandleKeyUp"/>
<p>@Data2</p>
@code {
    public string Data { get; set; }   
    public string Data2 { get; set; }  
    private System.Timers.Timer aTimer;
    protected override void OnInitialized()
    {
        aTimer = new System.Timers.Timer(1000);
        aTimer.Elapsed += OnUserFinish;
        aTimer.AutoReset = false;
    }
    void HandleKeyUp(UIKeyboardEventArgs e)
    {
        // remove previous one
        aTimer.Stop();
        // new timer
        aTimer.Start();        
    }    
    private void OnUserFinish(Object source, ElapsedEventArgs e)
    {
        InvokeAsync( () =>
            {
            Data2 = $"User has finish: {Data}";
            StateHasChanged();
            });
    }
}
### Use case:
One example of use case of this code is to avoid backend requests. The request is not sent until user stops typing.
### Running:
[![enter image description here][1]][1]
  [1]: https://i.stack.imgur.com/KIMsH.gif
