 
    protected override async Task OnMembersAddedAsync(IList<ChannelAccount> membersAdded, ITurnContext<IConversationUpdateActivity> turnContext, CancellationToken cancellationToken)
            {
                foreach (var member in membersAdded)
                {
                    if (member.Id != turnContext.Activity.Recipient.Id)
                    {
                        DateTime dateTime = DateTime.Now;
    
                        DateTime utcTime = dateTime.ToUniversalTime();
    
                        TimeZoneInfo cstZone = TimeZoneInfo.FindSystemTimeZoneById("China Standard Time");
    
                        DateTime yourLocalTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, cstZone);
                       
                     
                        if (yourLocalTime.Hour <= 12)
                        {
                           
                            await turnContext.SendActivityAsync(MessageFactory.Text($"Hello {member.Name}, good morning"), cancellationToken);
                        }
                        else if (yourLocalTime.Hour > 12)
                        {
    
                            await turnContext.SendActivityAsync(MessageFactory.Text($"Hello {member.Name}, good afternoon"), cancellationToken);
                        }
                        else if (yourLocalTime.Hour > 17)
                        {
    
                            await turnContext.SendActivityAsync(MessageFactory.Text($"Hello {member.Name}, good evening"), cancellationToken);
                        }
                        else
                        {                      
                            await turnContext.SendActivityAsync(MessageFactory.Text($"Hello {member.Name} " + yourLocalTime), cancellationToken);
                        }
    
    
                    }
                }
            }
