	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	namespace IFooedYouOnce
	{
		// IFoo
		//
		// It's personality is so magnetic, it's erased hard drives.
		// It can debug other code... by actually debugging other code.
		// It can speak Haskell... in C. 
		//
		// It *is* the most interesting interface in the world.
		public interface IFoo
		{       
			// didn't end up using this but it's still there because some
			// of the supporting derived classes look silly without it.
			bool CanChain { get; }
			string FooIdentifier { get; }
			// would like to place constraints on this in derived methods
			// to ensure type safety, but had to use exceptions instead.
			// Liskov yada yada yada...
			IFoo MakeTyped<TFoo>(EFooOpts fooOpts);
		}
		// using IEnumerable<IFoo> here to take advantage of covariance;
		// we can have lists of derived foos and just cast back and 
		// forth for adding or if we need to use the derived interfaces.
		// made it into a separate class because probably there will be
		// specific operations you can do on the chain collection as a
		// whole so this way there's a spot for it instead of, say, 
		// implementing it all in the FooManager
		public class FooChains : Dictionary<IFoo, IEnumerable<IFoo>> { }
		// manages the foos. very highly important foos.
		public class FooManager
		{
			private FooChains myChainList = new FooChains();
			// would perhaps add a new() constraint here to make the 
			// creation a little easier; could drop the whole MakeTyped
			// method.  but was trying to stick with the interface from
			// the question.
			void CopyAndChainFoo<TFoo>(TFoo fromFoo) where TFoo : IFoo
			// void MyMethod<T>(T f) where T : IFoo
			{
				TFoo toFoo;
				// without generics, I would probably create a factory
				// method on one of the base classes that could return
				// any type, and pass in a type. other ways are possible,
				// for instance, having a method which took two IFoos, 
				// fromFoo and toFoo, and handling the Copy elsewhere.
				// could have bypassed this try/catch altogether because
				// MakeTyped functions throw if the types are not equal,
				// but wanted to make it explicit here. also, this gives
				// a more descriptive error which, in general, I prefer
				try
				{
					// MakeTyped<TFoo> was a solution to allowing each TFoo
					// to be in charge of creating its own objects
					toFoo = 
						(TFoo)fromFoo.MakeTyped<TFoo>(EFooOpts.ForChain);
				}
				catch (Exception Ex) {
					// tried to eliminate the need for this try/catch, but
					// didn't manage. can't constrain the derived classes'
					// MakeTyped functions on their own types, and didn't
					// want to change the constraints to new() as mentioned
					throw 
						new FooChainTypeMismatch(typeof(TFoo), fromFoo, Ex);
				}
				// a list of specific type foos to hold the chain
				List<TFoo> typedFoos;
				if (!myChainList.Keys.Contains(fromFoo))
				{
					// we just create a new one and link it to the fromFoo
					// if none already exists
					typedFoos = new List<TFoo>();
					myChainList.Add(fromFoo, (IEnumerable<IFoo>)typedFoos);
				}
				else
					// otherwise get the existing one; we are using the 
					// IEnumerable to hold actual List<TFoos> so we can just
					// cast here.
					typedFoos = (List<TFoo>)myChainList[fromFoo];
				// add it in!
				typedFoos.Add(toFoo);
			}
		}
		[Flags]
		public enum EFooOpts
		{
			ForChain   = 0x01,
			FullDup    = 0x02,
			RawCopy    = 0x04,
			Specialize = 0x08
		}
		// base class, originally so we could have the chainable/
		// non chainable distinction but that turned out to be 
		// fairly pointless since I didn't use it. so, just left
		// it like it was anyway so I didn't have to rework all 
		// the classes again.
		public abstract class FooBase : IFoo
		{
			public string FooIdentifier { get; protected set; }
			public abstract bool CanChain { get; }
			public abstract IFoo MakeTyped<TFoo>(EFooOpts parOpts);
		}
		public abstract class NonChainableFoo : FooBase
		{
			public override bool CanChain { get { return false; } }
		}
		public abstract class ChainableFoo : FooBase
		{
			public override bool CanChain { get { return true; } }
		}
		// not much more interesting to see here; the MakeTyped would
		// have been nicer not to exist, but that would have required
		// a new() constraint on the chains function.  
		//
		// or would have added "where TFoo : MarkIFoo" type constraint
		// on the derived classes' implementation of it, but that's not 
		// allowed due to the fact that the constraints have to derive
		// from the base method, which had to exist on the abstract 
		// classes to implement IFoo.
		public class MarkIFoo : NonChainableFoo
		{
			public MarkIFoo()
				{ FooIdentifier = "MI_-" + Guid.NewGuid().ToString(); }
			public override IFoo MakeTyped<TFoo>(EFooOpts fooOpts) 
			{
				if (typeof(TFoo) != typeof(MarkIFoo))
					throw new FooCopyTypeMismatch(typeof(TFoo), this, null);
				return new MarkIFoo(this, fooOpts);
			}
			private MarkIFoo(MarkIFoo fromFoo, EFooOpts parOpts) :
				this() { /* copy MarkOne foo here */ }
		}
		public class MarkIIFoo : ChainableFoo
		{
			public MarkIIFoo()
				{ FooIdentifier = "MII-" + Guid.NewGuid().ToString(); }
			public override IFoo MakeTyped<TFoo>(EFooOpts fooOpts)
			{
				if (typeof(TFoo) != typeof(MarkIIFoo))
					throw new FooCopyTypeMismatch(typeof(TFoo), this, null);
				return new MarkIIFoo(this, fooOpts);
			}
			private MarkIIFoo(MarkIIFoo fromFoo, EFooOpts parOpts) :
				this() { /* copy MarkTwo foo here */ }
		}
		// yep, really, that's about all. 
		public class FooException : Exception
		{
			public Tuple<string, object>[] itemDetail { get; private set; }
			public FooException(
				string message, Exception inner,
				params Tuple<string, object>[] parItemDetail
			) : base(message, inner)
			{
				itemDetail = parItemDetail;
			}
			public FooException(
				string msg, object srcItem, object destType, Exception inner
			) : this(msg, inner,
				Tuple.Create("src", srcItem), Tuple.Create("dtype", destType)
			) { }
		}
		public class FooCopyTypeMismatch : FooException
		{
			public FooCopyTypeMismatch(
				Type reqDestType, IFoo reqFromFoo, Exception inner
			) : base("copy type mismatch", reqFromFoo, reqDestType, inner)
			{ }
		}
		public class FooChainTypeMismatch : FooException
		{
			public FooChainTypeMismatch(
				Type reqDestType, IFoo reqFromFoo, Exception inner
			) : base("chain type mismatch", reqFromFoo, reqDestType, inner)
			{ }
		}
	}
	// I(Foo) shot J.R.!
