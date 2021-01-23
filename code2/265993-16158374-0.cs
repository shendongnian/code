    public async Task Foo() {
        var x = await DoSomethingThatThrows();
    }
    public async void DoFoo() {
        try {
            await Foo();
        } catch (ProtocolException ex) {
            // This will catch exceptions from DoSomethingThatThrows
        }
    }
