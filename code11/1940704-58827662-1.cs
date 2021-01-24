    Activity activity = dialogContext.Context.Activity;
    object rawChannelData = activity.ChannelData;
    if (dialogContext.Context.Activity.Value != null && dialogContext.Context.Activity.Text == null)
    {
        dialogContext.Context.Activity.Text = turnContext.Activity.Value.ToString();
    }
