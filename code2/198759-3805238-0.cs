    public void SetValueOn(Array theArray, Object theValue)
    {
       if(theArray[0] is Array) //we haven't hit bottom yet
          for(int a=0;a<theArray.Length;a++)
             SetValueOn(theArray[a], theValue);
       else if(theValue.GetType().IsAssignableFrom(theArray[0].GetType()))
          for(int i=0;i<theArray.Length;i++)
             theArray[i] = theValue;
       else throw new ArgumentException(
             "theValue is not assignable to elements of theArray");
    }
