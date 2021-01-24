    class CompressingProducer
        {
    
            Queue<Object> _queue;
    
            public void ProduceData(object fileInputStream)
            {
                byte[] block = new byte[Settings.blockSize];
                int bytesRead;
    
                while ((bytesRead = ((Stream)fileInputStream).Read(block, 0, Settings.blockSize)) > 0)
                {
                    EnqueueObject(block);//Needs object of T type.
                    block = new byte[Settings.blockSize];
                }
            }
    
            private void EnqueueObject(Object data)
            {
                _queue.Enqueue(data);
            }
        }
