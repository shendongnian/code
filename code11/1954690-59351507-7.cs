    IEnumerator GetInputFromUser()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
             print("IN");
        }
    
        yield return null;
    }
