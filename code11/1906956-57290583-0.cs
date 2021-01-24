    var _onetime = false;
    public void Update()
    {
        if (!_onetime && TimeLevel.levelValue == 2)
        {
            timeBtwSpan -= decreaseSpawnTime;
            _onetime = true;
        }
    }
