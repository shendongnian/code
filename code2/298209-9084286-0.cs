    var startTime = DateTime.Now;
    int bazillion = 100000000;
    int[] list = {1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20};
    for (int i = 0; i < bazillion; i++)
    {
        for (int k = 0; k < list.Length; k++)
        {
            if (k >= 0)
            {
                list[k] = i;
            }
            else
            {
                // do nothing.
            }
        }
    }
    var executionTime = DateTime.Now - startTime;
    Debug.WriteLine (executionTime.TotalMilliseconds);
