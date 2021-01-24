    public float letterMoveTime = 1f; // duration of shuffle movement (in seconds)
    List<GameObject> letters;
    IEnumerator shuffleCoroutine;
    
    void Awake()
    {
        letters = new List<GameOobject>();
        letters.AddRange(GameObject.FindGameObjectsWithTag("Letter"));
    
        shuffleCoroutine = null;
    }
    
    public void StartShuffle() // call this on button click
    {
        if (shuffleCoroutine != null) return;
    
        shuffleCoroutine = DoShuffle();
        StartCoroutine(shuffleCoroutine);
    }
    
    IEnumerator DoShuffle()
    {
        List<Vector3> startPos = new List<Vector3>();
        List<Vector3> endPos = new List<Vector3>();
        foreach (GameObject letter in letters)
        {
            startPos.Add(letter.transform.position);
            endPos.Add(letter.transform.position);
        }
    
        // shuffle endPos
        for (int i = 0 ; i < endPos.Count ; i++) {
             Vector3 temp = endPos[i];
             int swapIndex = Random.Range(i, endPos.Count);
             endPos[i] = endPos[swapIndex];
             endPos[swapIndex] = temp;
         }
    
         float elapsedTime = 0f;
    
         while (elapsedTime < letterMoveTime)
         {
             // wait for next frame
             yield return null;
    
             // move each letter
             elapsedTime  = Mathf.Min(letterMoveTime, elapsedTime+Time.deltaTime);
             float t = elapsedTime / letterMoveTime;
          
             for (int i = 0 ; i < startPos.Count ; i++) {
                 letter[i].transform.position = Vector3.lerp(startPos[i],endPos[i],t);
             }
         }
    
         // allow shuffling to occur again
         shuffleCoroutine = null;
    }
