    private void SaveGlobalsAndDoSomething(Action doit)
    {
        var _oldValue = _variable;
        _variable = tempValue;
        try
        {
            doit();
        }
        finally
        {
            _variable = _oldValue;
        }
    }
