    public bool MoveNext()
    {
            if(i < 5)
            {
                i++;
                return true;
            }
            else
            {
                i = -1;
                return false;
            }
    }
