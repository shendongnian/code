        public static void Notify(string token, object args = null)
        {
            if (pl_dict.ContainsKey(token))
                foreach (var callback in pl_dict[token])
                {
                    Thread thread = new Thread(new ThreadStart(() =>
                    {
                        System.Windows.Application.Current.Dispatcher.Invoke(() =>
                        callback(args));
                    }));
                    thread.Start();
                };
        }
