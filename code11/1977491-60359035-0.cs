    > private void Update()
    >     {
    >         if (Input.GetKeyDown(KeyCode.Keypad0))
    >         {
    >             StartCoroutine(PrintTotalTime());
    >         }
    > 
    >         if (Input.GetKeyDown(KeyCode.Space))
    >         {
    >             StopPrintTotalTime();
    >             StartCoroutine(SpeedUp());
    >         }
    >     }
