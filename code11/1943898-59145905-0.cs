protected override async Task<InvokeResponse> OnInvokeActivityAsync(ITurnContext<IInvokeActivity> turnContext, CancellationToken cancellationToken)
{
    var connector = turnContext.TurnState.Get<IConnectorClient>();
    var conversation = turnContext.Activity.Conversation;
    IList<ChannelAccount> members;
    try
    {
        members = await connector.Conversations.GetConversationMembersAsync(conversation.Id, cancellationToken);
    }
    catch (ErrorResponseException ex)
    {
        // If the ErrorResponseException contains the response with status code 403, that means our bot is not a member of this conversation.
        // In that case, return an adaptive card containing the prompt to add the bot to the current conversation.
        // After accepting the prompt, the bot will be added to the conversation and we will be able to obtain the list of conversation participants.
        if (ex.Response.StatusCode == HttpStatusCode.Forbidden)
        {
            return new InvokeResponse
            {
                Status = 200,
                Body = AddBotToConversation()
            };
        }
        throw;
    }
    // At this point, we have the list of conversation members
    var otherMember = members.FirstOrDefault(x => x.Id != turnContext.Activity.From.Id);
    return new InvokeResponse
    {
        Status = 200,
        Body = await DoSomethingWithOtherMemberInformationAndReturnACard(otherMember, cancellationToken)
    };
}
Just make sure the messaging extension is action-based, not search-based. Search extensions will not support this approach.
