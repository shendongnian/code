            private async Task<DialogTurnResult> CodeActionSampleFn(DialogContext dc, System.Object options)
            {
                var userState = JObject.FromObject(dc.GetState().FirstOrDefault(x => x.Key == "user").Value);
        //Get your data here
                var data = userState.Value<JObject>("userProfile" + question.Id);
        // call your API by HttpClient
    //...
        return dc.ContinueDialogAsync();
            }
