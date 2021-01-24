    Coroutine Routine = null;
    void Example()
    {
        if (Routine != null)
        {
            StopCoroutine(Routine);
        }
        Routine = StartCoroutine(ExampleCoroutine());
    }
 
    IEnumerator ExampleCoroutine()
    {
        // do coroutine
        // end coroutine with:
        Routine = null;
    }
