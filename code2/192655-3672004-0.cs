    public void SampleMethod()
    {
        //client was injected somehow
        using(this.client as IDisposable)
        {
            ...
        }
    }
