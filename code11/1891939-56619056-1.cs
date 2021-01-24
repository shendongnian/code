    public interface ICommand {
        public Datetime Timestamp { get; private set; }
    }
    public class CommandIssuer {
        public CommandIssuerType Type { get; pivate set; }
        public CommandIssuerInfo Issuer {get; private set; }
    }
    public class CommandContext {
        public ICommand cmd { get; private set; }
        public CommandIssuer CommandIssuer { get; private set; }
    }
    public class CommandDispatcher {
        public void Dispatch(ICommand cmd, CommandIssuer issuer){
            LogCommandStarted(issuer, cmd);
            try {
                DispatchCommand(cmd);
                LogCommandSuccessful(issuer, cmd);
            }
            catch(Exception ex){
                LogCommandFailed(issuer, cmd, ex);
            }
        }
        // or
        public void Dispatch(CommandContext ctx) {
            // rest is the same
        }
    }
