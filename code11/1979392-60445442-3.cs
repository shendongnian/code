    public abstract class CompressingProducer<T>
    {
        public Queue<T> Queue { get; set; }
        public abstract void ProduceData(object fileInputStream);
        protected void EnqueueObject(T element)
        {
            Queue.Enqueue(element);
        }
    }
    public class CompressingProducerByByteArray : CompressingProducer<byte[]>
    {
        public override void ProduceData(object fileInputStream)
        {
            byte[] block = new byte[Settings.blockSize];
            while (((Stream)fileInputStream).Read(block, 0, Settings.blockSize) > 0)
            {
                EnqueueObject(block);
                block = new byte[Settings.blockSize];
            }
        }
    }
