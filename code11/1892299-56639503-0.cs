    await base.OnTurnAsync(turnContext, cancellationToken);
        
        if (turnContext.Activity.Type is ActivityTypes.Message)
        {
        string userInput = turnContext.Activity.Text;
        
                        // LoadAsync doesn't seem to set any data
                        await _userState.LoadAsync(turnContext, false, cancellationToken);
        
                        var userStateAccessors = _userState.CreateProperty<ClientProfile>(nameof(ClientProfile));
                        var client = await userStateAccessors.GetAsync(turnContext, () => new ClientProfile());
        
                        await turnContext.SendActivityAsync($"You wrote {userInput}, Session {client.Name}");
        
                        await turnContext.SendActivityAsync($"Content {content}");
                        //Add this line
                        await _userState.SaveChangesAsync(turnContext, false, cancellationToken);
                    }
