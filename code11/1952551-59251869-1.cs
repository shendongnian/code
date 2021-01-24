    private Coroutine betSpinWheelCoroutine
    // The button should call this
    public void BetSpinWheel() {
        // Stop the coroutine first if it was running.
        if (betSpinWheelCoroutine != null){
            StopCoroutine(betSpinWheelCoroutine);
        }
        betSpinWheelCoroutine = StartCoroutine(BetSpinWhellCoroutine());
    }
    
    private IEnumerator BetSpinWheelCoroutine() {
        // Your bet stuff here
    }
