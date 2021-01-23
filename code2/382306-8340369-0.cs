    class AsyncFileCopier
    {
        BackgroundWorker _worker;
    
        void OnNewFile(string fileName)
        {
            _queue.Enqueue(fileName);
            EnsureWorkerIsRunning();
        }
    
        void EnsureWorkerIsRunning(9)
        {
            if(!_worker.IsBusy)
                _worker.RunWorkerAsync();
        }
    
        void OnWorkerDoWork(...)
        {
            string fileName;
            while(_queue.TryDequeue(out fileName)
            {
                CopyFile(fileName);
            }
        }
    }
