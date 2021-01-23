    public sealed ExecutionManager() {
        TResult Execute<TResult>(IExecutable<TResult> action) {
            var connection = OhOnlyIKnowHowTOGetTheConnectionAnfHereItIs();
            action.Execute(connection);
            return action.Result;
        }
    }
