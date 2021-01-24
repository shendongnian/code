    private bool _pause = false;
    private void Start()
    {
      StartCoroutine(FuncName());
    }
    
    private void Update()
    {
      if (Input.GetKeyDown(KeyCode.Return))
      {
        _pause = !_pause;
      }
    }
    private IEnumerator FuncName()
    {
      for(int i = 0; i < 10; i++)
      {
        while (_pause)
        {
          yield return null;
          print (i);
        }
      }
    }
