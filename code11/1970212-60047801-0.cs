    IEnumerator sitIdle()
    {
        var timeToWait = GetIdleTime();
        _isIdle = true;
        yield return new WaitForSeconds(timeToWait);
        _isIdle = false;
    }  
    IEnumerator sitIdleAlternative()
    {
        var timeToWait = GetIdleTime() + 2f;
        _isIdle = true;
        yield return new WaitForSeconds(timeToWait);
        _isIdle = false;
    }
    delegate IEnumerator IdleDelegate ();
    IdleDelegate _idleRoutine;
    void LateUpdate()
    {
        _idleRoutine = new IdleDelegate(sitIdleAlternative); //this is not actually in the late update, just moved here for reference.
        _idleRoutine = new IdleDelegate(sitIdle);
        if (_agent.hasPath)
        {
            if (isTouchingTarget())
            {
                StartCoroutine(sitIdle2()); //Scenario #1
                StartCoroutine(_idleRoutine()); //Scenario #2
                _currentTarget = null; 
                _agent.ResetPath();
            }
        }
    }
