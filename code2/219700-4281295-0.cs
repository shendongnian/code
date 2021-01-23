	class BL
	{
		public void CallFromFL (int parameter)
		{
			int result = DoSomeWork (parameter);
			if (OnComplete != null)
				OnComplete (result);
		}
		public event Action <int> OnComplete;
	}
	class FL
	{
		void Foo ()
		{
			BL bl = new BL ();
			bl.OnComplete += this.getResult;
			bl.CallFromFL (5);
		}
		
		void GetResult (int result) {...}
	}
