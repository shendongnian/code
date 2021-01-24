    protected override async Task OnEventAsync(DialogContext dc, CancellationToken cancellationToken = default(CancellationToken))
        {
            var value = dc.Context.Activity.Value;
            if (value.GetType() == typeof(JObject))
            {
                var result = await dc.ContinueDialogAsync();
                return;
            }
        }
