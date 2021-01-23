    class MyQueue<TJob> where TJob : ITask 
    {
        Queue<TJob> high, med, low;
        bool GetNextJob(ref TJob work)
        {
            if(work.Priority == PriorityType.High && !work.Complete)
                return true;
            lock(this)
            {
                if(high.Count > 0)
                {
                    Enqueue(work);//requeue to pick back up later
                    work = high.Dequeue();
                    return true;
                }
                if(work.Priority == PriorityType.Med && !work.Complete)
                    return true;
                if(med.Count > 0)
                {
                    Enqueue(work);//requeue to pick back up later
                    work = med.Dequeue();
                    return true;
                }
                if(!work.Complete)
                    return true;
                if(low.Count > 0)
                {
                    work = low.Dequeue();
                    return true;
                }
                work = null;
                return false;
            }
        void Enqueue(TJob work)
        {
            if(work.Complete) return;
            lock(this)
            {
                else if(work.Priority == PriorityType.High) high.Enqueue(work);
                else if(work.Priority == PriorityType.Med) med.Enqueue(work);
                else low.Enqueue(work);
            }
        }
    }
