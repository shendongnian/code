	MyDelegate _BackingDelegate;
	event MyDelegate MyEvent
	{
		add { this._BackingDelegate += value; }
		remove { this._BackingDelegate -= value; }
	}
