ConcurrentQueue<MethodToExecute> threadSafeQueue = new ConcurrentQueue<MethodToExecute>();
    private void Update()
    {
        if (threadSafeQueue.Count > 0)
        {
            MethodToExecute changeUI;
            threadSafeQueue.TryDequeue(out changeUI);
            changeUI.action(changeUI.oldState, changeUI.state);
        }
    }
    private void Start()
    {
        StoreCreator.GetInstance.store.Subscribe += LoginSubscirber;
    }
    private void LoginSubscirber(AppState oldState, AppState state)
    {
        lock (state)
        {
            if (oldState.loginState != state.loginState)
            {
                if (state.loginState == loginStateEnum.loadingLogin)
                {
                    threadSafeQueue.Enqueue(new MethodToExecute(LoadingLoginCallback, oldState, state));
                }
                else if (state.loginState == loginStateEnum.successLogin)
                {
                    threadSafeQueue.Enqueue(new MethodToExecute(LoginSuccescCallback, oldState, state));
                }
                else if (state.loginState == loginStateEnum.failLogin)
                {
                    threadSafeQueue.Enqueue(new MethodToExecute(LoginFailCallback, oldState, state));
                }
                /*lock (oldState)
                {
                    this.oldState = oldState;
                    this.state = state;
                }*/
            }
        }
    }
