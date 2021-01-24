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
You need to use `[Remainder]` because otherwise in a command such as:
$ban @User Sending NSFW Pics
Everything after "Sending" would be considered as extra parameters and not part of `reason`. Therefore, the command would fail since it only accepts two parameters.
That said, the command should word if you don't specify a reason. Is this true?
On a side not, use camelCasing for variable names. So I would suggest using `user` instead of `User`. It can become confusing since `User` may be interpreted as a class if the syntax highlighting is not clear or when using any extensions.
