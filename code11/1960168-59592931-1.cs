    List<ChannelAccount> teamMembers = (await turnContext.TurnState.Get<IConnectorClient>().Conversations.GetConversationMembersAsync(
                    turnContext.Activity.GetChannelData<TeamsChannelData>().Team.Id).ConfigureAwait(false)).ToList();
    
                List<MicrosoftTeamUser> teamsUsers = new List<MicrosoftTeamUser>();
                foreach (var item in teamMembers)
                {
                    var teamsUser = JsonConvert.DeserializeObject<MicrosoftTeamUser>(item.Properties.ToString());
                    teamsUser.Id = item.Id;
                    teamsUsers.Add(teamsUser);
                }
