    private static void FirstMethod(List<T> templist, ref bool CopyOk)
    {
        T[] temp;
		
		lock (templist)
		{
			temp = new T[templist.Count];
			templist.CopyTo(temp);
		}
        CopyOk = true;
        //moves on
    }
