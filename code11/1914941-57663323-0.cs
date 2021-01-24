      Coroutine c1;
        Coroutine c2;
    
        void runCourotines()
        {
            c1 = StartCoroutine(MoveToX());
            c2 = StartCoroutine(MoveToX());
    
        }
    
        void StopCoroutines()
        {
            StopCoroutine(c1);
        }
