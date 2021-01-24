    class Test {
        protected virtual Task<bool> SetupAsync() {
            return Task.FromResult(true);
        }
    }
    
    class Test2 : Test {
        protected override async Task<bool> SetupAsync() {
            await Task.Delay(1000);
            return false;
        }
    }
