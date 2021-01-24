 namespace bot.Core.Commands
 {
    public class Kick : ModuleBase<SocketCommandContext>
    {
        [Command("kick"), Summary("")]
        public async Task kick(IGuildUser user, [Remainder] string reason = "no reason")
        {
            User.KickAsync(reason);
        }
    }
 }
Otherwise, in a command such as:
$ban @User Sending NSFW Pics
Everything after "Sending" would be considered as extra parameters and not part of `reason`. Therefore, the command would fail since it only accepts two parameters.
That said, the command should word if you don't specify a reason. Is this true?
On a side note, use camelCasing for variable names. So I would suggest using `user` instead of `User`. It can become confusing if there is no syntax highlighting among an array of other reasons. See how StackOverflow has automatically highlighted it in your post when variables should remain black.
