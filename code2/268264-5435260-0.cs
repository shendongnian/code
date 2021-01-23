    if (this._wr is IIS7WorkerRequest)
    {
        this.Headers.Add(HttpResponseHeader.MaybeEncodeHeader(name), HttpResponseHeader.MaybeEncodeHeader(value));
    }
    else if (flag)
    {
        if (this._cacheHeaders == null)
        {
            this._cacheHeaders = new ArrayList();
        }
        this._cacheHeaders.Add(new HttpResponseHeader(knownResponseHeaderIndex, value));
    }
