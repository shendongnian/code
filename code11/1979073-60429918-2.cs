     dynamic checkUserInput = turnContext.Activity.Text;
                    //Check Each User Input
                    switch (checkUserInput.ToLower())
                    {
                        case "me":
                            await turnContext.SendActivityAsync(MessageFactory.Text("You have typed me"), cancellationToken);
                           
                            await turnContext.SendActivityAsync(MessageFactory.Text("Once you begin using solution workspace, you'll see checklist that will be help you too:"), cancellationToken);
                            //You can add any additional flow here if needed
                            var overview = OverViewFlow();
                            await turnContext.SendActivityAsync(overview).ConfigureAwait(false);
                            break;
                        case "send":
						      await turnContext.SendActivityAsync(MessageFactory.Text("You have typed send"), cancellationToken);
                             break;
                          default: //When nothing found in user intent
                            await turnContext.SendActivityAsync(MessageFactory.Text("What are you looking for?"), cancellationToken);
                            break;
                    }
