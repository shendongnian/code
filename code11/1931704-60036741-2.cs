c#
    @typeparam TResult
    @typeparam TInput
    @if (Result != null)
    {
        @DataReadyFragment(Result)
    }
    else if (DataMissingFragment != null)
    {
        @DataMissingFragment
    }
    @code {
        [Parameter] public RenderFragment<TResult> DataReadyFragment { get; set; }
        [Parameter] public RenderFragment DataMissingFragment { get; set; }
        [Parameter] public Func<TInput, Task<TResult>> AsyncOperation { get; set; }
        [Parameter] public TInput Input { get; set; }
        TResult Result { get; set; }
    
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            AsyncOperation.Invoke(Input).ContinueWith(t => { Result = t.Result; InvokeAsync(StateHasChanged); });
        }
    }
**Usage**
    <AsyncComponent TResult="User" TInput="string" Input="Pa$$W0rd" AsyncOperation="@AsyncMethodName">
        <DataReadyFragment Context="result">
            @if(result.IsLoggedIn)
             {
               <h3>Logged-In , Username:@result.Name</h3>
             }
             else
             {
              <h3>Wrong Password</h3>
             }
        </DataReadyFragment>
        <DataMissingFragment>
            <h3>Please Login :)</h3>
        </DataMissingFragment>
    </AsyncComponent>
