	MyDelegate _BackingDelegate;
	event MyDelegate MyEvent
	{
		add { lock (this._BackingDelegate) this._BackingDelegate += value; }
		remove { lock (this._BackingDelegate) this._BackingDelegate -= value; }
	}
