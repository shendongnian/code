		// to manage our foos and their chains. very important foo chains.
		public class FooManager
		{
			private FooChains myChainList = new FooChains();
			// void MyMethod<T>(T f) where T : IFoo
			void CopyAndChainFoo<TFoo>(TFoo fromFoo) where TFoo : IFoo
			{
				TFoo toFoo;
				try {
					// create a foo from the same type of foo
					toFoo = (TFoo)fromFoo.MakeTyped<TFoo>(EFooOpts.ForChain);
				}
				catch (Exception Ex) {
					// hey! that wasn't the same type of foo!
					throw new FooChainTypeMismatch(typeof(TFoo), fromFoo, Ex);
				}
				// a list of a specific type of foos chained to fromFoo
				List<TFoo> typedFoos;
				if (!myChainList.Keys.Contains(fromFoo))
				{
					// no foos there! make a list and connect them to fromFoo
					typedChain = new List<TFoo>();
					myChainList.Add(fromFoo, (IEnumerable<IFoo>)typedChain);
				}
				else
					// oh good, the chain exists, phew!
					typedChain = (List<TFoo>)myChainList[fromFoo];
				// add the new foo to the connected chain of foos
				typedChain.Add(toFoo);
				// and we're done!
			}
		}
