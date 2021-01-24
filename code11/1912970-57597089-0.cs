csharp
using Microsoft.Bot.Builder;
using Microsoft.BotBuilderSamples;
namespace Microsoft.BotBuilderSamples
{
    public class BasicAccessors
    {
        public IStatePropertyAccessor<ConversationData> ConversationStateAccessors { get; }
        public IStatePropertyAccessor<UserProfile> UserStateAccessors { get; }
        public StateAccessors(ConversationState conversationState, UserState userState)
        {
            ConversationStateAccessors = conversationState.CreateProperty<ConversationData>(nameof(ConversationData));
            UserStateAccessors = userState.CreateProperty<UserProfile>(nameof(UserProfile));
        }
    }
}
Notice how the properties each get set with the actual accessor via `*State.CreateProperty<*>(nameof(*));`
Then, in `Startup.cs`, you just need:
csharp
services.AddSingleton<StateAccessors>();
services.AddSingleton<MyDialogThatNeedsAccessors>(); // Call this for each of your Dialogs
Then, in your dialogs that need the accessors,
csharp
public MyDialogThatNeedsAccessors(BasicAccessors stateAccessors)
{
    _userProfileAccessor = stateAccessors.UserStateAccessors;
}
Then, to access it within your dialog, you just do something like:
csharp
var userProfile = await _userProfileAccessor.GetAsync(stepContext.Context, () => new UserProfile());
For dialogs that don't need the accessors, just leave it out of the constructor.
