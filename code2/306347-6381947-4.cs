    Timer CreateTimer(object unitID)
    {
        object   row      = ...
        TimeSpan dueTime  = ...
        TimeSpan interval = ...
        
        $Temp temp = new $Temp (unitID);
        return new Timer(temp.Callback, row, dueTime, interval);
    }
    class $Temp
    {
        public $Temp(object arg)
        {
            this.arg = arg;
        }
        public void Callback(object x)
        {
            DataTransfer (x, this.arg);
        }
        private object arg;
    }
