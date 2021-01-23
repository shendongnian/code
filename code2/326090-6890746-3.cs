        // your async callback
        public void ObjectWasDeserialized(IAsyncResult result)
        {
            _dispatcher.Invoke(new Action<IAsyncResult>(UpdateSomeControl), result);
        }
