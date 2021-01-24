    private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Keypad0) && !_0pressedAlready)
            {
                _0pressedAlready = true;
                StartCoroutine(PrintTotalTime());
            }
    
            if (Input.GetKeyDown(KeyCode.Space) && !_spacePressedAlready)
            {
                _spacePressedAlready = true;
                StopPrintTotalTime();
                StartCoroutine(SpeedUp());
            }
        }
    
