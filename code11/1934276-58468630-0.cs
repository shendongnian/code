    public async Task Start() {
        while(true) {
            try {
                var context = await _listener.GetContextAsync().ConfigureAwait(false);// it stays here
                HandleRequest(context); // handle incoming requests
            } catch (HttpListenerException e) {
                // examine e.ErrorCode to see what the problem was and
                // decide to continue or return
            } catch (Exception e) {
                // decide to continue or return
            }
        }
    }
