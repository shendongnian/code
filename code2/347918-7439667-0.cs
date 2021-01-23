        public class LimitedQueue : Queue
        {
            public override void Enqueue(object obj)
            {
                if (this.Count > 5)
                    throw new Exception();
    
                if(this.Contains(obj))
                    throw new Exception();
                base.Enqueue(obj);
            }
        }
