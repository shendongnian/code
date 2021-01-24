    public void Main()
    {
        using(var largeClass = new LargeClassObject(param1, param2))
        {
            try
            {
                DoSomethingWithObject(largeClass);
            }
            catch(Exception ex)
            {
                //Do any additional cleanup
            }
        }
    }
