    public class MyStreamManager {
        public delegate bool ValidChunkTester(StringBuilder builder);
        private readonly List<ValidChunkTester> validators = new List<ValidChunkTester>();
        public event ValidChunkTester IsValidChunk
        { add{validators.Add(value);} remove {validators.Remove(value);}}
        public event EventHandler<ConsoleOutputReadEventArgs> StandardOutputRead;
        
    
        public void StartSendingEvents();
        public void StopSendingEvents();
    }
    ...
    private void ReadHappened(IAsyncResult asyncResult)
    {
        var bytesRead = this.StandardOutput.BaseStream.EndRead(asyncResult);
        if (bytesRead == 0) {
            this.OnAutomationStopped();
            return;
        }
        var input = this.StandardOutput.CurrentEncoding.GetString(
            this.buffer, 0, bytesRead);
        this.inputAccumulator.Append(input);
        if (validators.Any() && StandardOutputRead !-= null 
                && validators.Aggregate(true, (valid, validator)=>valid && validator(inputAccumulator))) {
            this.OnInputRead(); // send when all listeners can work with the buffer contents
        }
        this.BeginReadAsync(); // continue "looping" with BeginRead
    }
    ...
