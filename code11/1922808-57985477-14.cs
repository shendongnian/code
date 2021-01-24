    public void OnPhaseOne(GameControl gCon) 
    {
        StartCoroutine(PhaseOneRoutine());
    }
    private IEnumerator PhaseOneRoutine()
        // *** EVENT CARDS ***
        
        // if there is only one in the sene you can simply use
        DisplayManager dMan = FindObjectOfType<DisplayManager>();
        // in general you should rather do it in Awake and only once
        yield return dMan.DoDisplayRoutine("Take 2 Cards, update Red Count");
        // Check for 6+ Event Cards
        if (gCon.Cards >= 6) {
            yield return dMan.DoDisplayRoutine("Discard a Card\n Discard Order:\n1. 2. 3. 4.");
        }
        // Allow for Exchange
        if (gCon.Cards == 2) {
            yield return dMan.DoDisplayRoutine("Exchange Card as Required");
        }
    }
