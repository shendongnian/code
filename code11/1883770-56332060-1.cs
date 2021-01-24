var attributedString= await GetAttributedStringAsync();
        public Task<NSAttributedString> GetAttributedStringAsync()
        {
            var tcs = new TaskCompletionSource<NSAttributedString>();
            DispatchQueue.MainQueue.DispatchAsync(() =>
            {
                tcs.SetResult(new NSAttributedString(myHtmlData, options, out dict, ref error););
            });
            return tcs.Task;
        }
