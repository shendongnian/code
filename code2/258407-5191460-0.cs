    IEnumerable blah = ...; // note non-generic version
    IEnumerator iter = blah.GetEnumerator();
    using(iter as IDisposable)
    {
        // loop
    }
