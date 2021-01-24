     // innderDc is the **DialogContext**
     var activity = innerDc.Context.Activity;
    // Check activity type
    switch (activity.Type) {
     case ActivityTypes.ConversationUpdate:
         {
             if (activity.MembersAdded ? .Count > 0) {
                 foreach(var member in activity.MembersAdded) {
                   // do logic
                    await innerDc.BeginDialogAsync(nameof("yourDialog"));
                 }
             }
             break;
         }
