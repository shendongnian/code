    public void doLevel(int level)
    {
      for (int i = 0; i < 6; i++)
      { 
         if(method(i, level))
           doLevel(level +1);
      }
    }
    private bool method(int value, int level)
    {
        //use int 'level' and 'value'
        //determine bool 'next'
    }
