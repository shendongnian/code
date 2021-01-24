   		public RetType HandlingMethod<P1Type,RetType>(Func<P1Type, RetType> method, P1Type p)
		{
			try
			{
				return method(p);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
				throw;
			}
		}
		public RetType HandlingMethod<P1Type, P2Type, RetType>(Func<P1Type, P2Type, RetType> method, P1Type p1, P2Type p2)
		{
			try
			{
				return method(p1, p2);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
				throw;
			}
		}
