    private sealed class SetupClass : IDisposable {
        public SetupClass() {
            // setup
        }
        public void Dispose() {
            // cleanup
        }
    }
    void Method1() {
        using (SetupClass setup = new SetupClass() {
            // do stuff here
        }
    }
    void Method2() {
        using (SetupClass setup = new SetupClass() {
            // do stuff here
        }
    }
