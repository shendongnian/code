    public interface IPublisher {
        long GetMessageCount(string msg);
    }
    public class Publisher : IPublisher {
        private readonly IPublisher publisher;
        public Publisher(IPublisher publisher) {
            this.publisher = publisher;
        }
        public long GetMessageCount(string msg) {
            long result = 0;
            try {
                if (msg == "abc")
                    throw new Exception();
                result = publisher.GetMessageCount(msg);
                return result;
            } catch (Exception ex) {
                var p = ex.Message;
                return result = -1;
            }
        }
    }
