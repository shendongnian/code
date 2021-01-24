    void Update()
    {
    //--- some code here.
        if (Input.GetMouseButtonDown(0))
        {
            if(CanDrawLine)  //Checking if allowed to create line
               CreateLine();
        }
        if (Input.GetMouseButton(0))
        {
            if(CanDrawLine)  //Checking if allowed to create line
            {
                Vector2 tempFingerPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                if (Vector2.Distance(tempFingerPos, fingerPositions[fingerPositions.Count - 1]) > .1f)
                {
                    UpdateLine(tempFingerPos);
                }
            }
        }
    //--- some code here
    }
    
    [SerializeField]
    int m_maxCountToCreate = 10;
    int m_numberOfLinesCreated = 0;
    
    bool CanDrawLine
    {
       get { return m_numberOfLinesCreated == m_maxCountToCreate; }
    }
    
    
    void CreateLine()
    {
        m_numberOfLinesCreated++;
        // your code here.
    }
