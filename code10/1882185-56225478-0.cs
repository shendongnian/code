    public class HasConstructorWithAsyncCall
    {
        public HasConstructorWithAsyncCall()
        {
            MarkConstructorFinishedAsync();
        }
        
        public bool ConstructorHasFinished { get; private set; }
        async void MarkConstructorFinishedAsync()
        {
            await Task.Delay(500);
            ConstructorHasFinished = true;
        }
    }
