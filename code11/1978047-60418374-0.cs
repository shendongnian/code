CSharp
public override Task ApplyTokenResponse(ApplyTokenResponseContext context)
{
    if (context.Ticket != null)
    {
        foreach (var property in context.Ticket.Properties.Items)
        {
            context.Response.AddParameter(property.Key, property.Value);
        }
    }
    return Task.CompletedTask;
}
