    IEnumerator Start()
    {
        Debug.Log("First frame i'm being enabled! yeee");
        // After 2 seconds i'm gonna blink
        yield return new WaitForSeconds(2.0f);
        Debug.Log("I'm going to blink");
        Blink();
    }
