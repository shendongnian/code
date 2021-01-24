    private async Task ShootAsync(
        ITurnContext turnContext,
        CancellationToken cancellationToken)
    {
        var activity = turnContext.Activity;
        if (activity.ChannelId == Channels.Msteams)
        {
            var value = JObject.FromObject(activity.Value);
            var cardId = Convert.ToString(value[BotUtil.KEYCARDID]);
            var dict = await BattleshipStateAccessor.GetAsync(
                turnContext,
                () => new Dictionary<string, (string, List<string>)>(),
                cancellationToken);
            if (dict.TryGetValue(cardId, out var savedInfo))
            {
                savedInfo.Shots.Add(value["id_shoot"].ToString());
                var data = new
                {
                    name = "Test shot",
                    shoots = savedInfo.Shots.Select(shot => new
                    {
                        shoot = shot,
                        status = DetermineHit(shot),
                    }),
                };
                var update = CreateBattleshipCardActivity(cardId, data);
                update.Id = savedInfo.ActivityId;
                update.Conversation = activity.Conversation;
                await turnContext.UpdateActivityAsync(update, cancellationToken);
            }
        }
    }
