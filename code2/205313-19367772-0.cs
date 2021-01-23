    public IEnumerator GetEnumerator()
    {
        this.Reset(); // Reset each time you get the Enumerator
        return (IEnumerator)this;
    }
