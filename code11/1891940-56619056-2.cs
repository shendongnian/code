    public class SomethingAggregate {
        public void Handle(CommandCtx ctx) {
            RecordCommandIssued(ctx);
            Process(ctc.cmd);
        }
    }
