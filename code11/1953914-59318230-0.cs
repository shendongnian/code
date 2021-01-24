private async Task RunInitAndSetParametersAsync()
{
    OnInitialized();
    var task = OnInitializedAsync();       <b> NO await here !</b>
    if (task.Status != TaskStatus.RanToCompletion && task.Status != TaskStatus.Canceled)
    {
        // Call state has changed here so that we render after the sync part of OnInitAsync has run
        // and wait for it to finish before we continue. If no async work has been done yet, we want
        // to defer calling StateHasChanged up until the first bit of async code happens or until
        // the end. Additionally, we want to avoid calling StateHasChanged if no
        // async work is to be performed.
        StateHasChanged();                  <b>Notify here! (happens before await)</b>
        try
        {
            await task;                     <b>await the OnInitializedAsync to complete!</b>
        }
        ...
