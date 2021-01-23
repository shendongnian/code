        public void Example()
        {
            //call using a thread.
            ThreadPool.QueueUserWorkItem(p => check_news("title", "news message"));
        }
        private void check_news(string news, string newsMessage)
        {
            
        }
