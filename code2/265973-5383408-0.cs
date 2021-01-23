    public void DoFoo()
    {
        try
        {
            await Foo();
        }
        catch (ProtocolException ex)
        {
              /* The exception will be caught because you've awaited the call. */
        }
    }
