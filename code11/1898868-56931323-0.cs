    public class StringContainer
    {
        public string String { get; set; }
    }
    static async void Foo(StringContainer container)
    {
        var progress = new Progress<string>(update => container.String = update);
        await Task.Run(() => MyAsyncUpdaterMethod(progress));
    }
