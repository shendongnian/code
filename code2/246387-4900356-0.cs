	public interface IExecuteStrategy
	{
		string TransactionType {get;}
		void Execute( string xmlData );
	}
	public class WsProxy1Adapter : IExecuteStrategy
	{
		public string TransactionType
		{
			get { return "1"; }
		}
		public void Execute(string xmlData)
		{
			Type1 type1Object = ( new Deserializer<Type1>() ).XML2Object( XML );
			var ws = new WSProxy1();
			string response = ws.Method1( type1Object );
			//
			// lots of other lines of code that use type1VO, type1Object, the response, etc.
			//
		}
	}
	public class WsProxy2Adapter : IExecuteStrategy
	{
		public string TransactionType
		{
			get { return "2"; }
		}
		public void Execute(string xmlData)
		{
			Type2 type2Object = ( new Deserializer<Type2>() ).XML2Object( XML );
			var ws = new WSProxy2();
			string response = ws.Method1( type2Object );
			//
			// lots of other lines of code that use type1VO, type1Object, the response, etc.
			//
		}
	}
	public class MyClass
	{
		private static Dictionary<string, IExecuteStrategy> _transactionHandlers;
		static MyClass()
		{
			_transactionHandlers = new Dictionary<string,IExecuteStrategy>();
			IExecuteStrategy obj = new WsProxy1Adapter();
			_transactionHandlers.Add(obj.TransactionType, obj);
			obj = new WsProxy2Adapter();
			_transactionHandlers.Add(obj.TransactionType, obj);
		}
		public void MyMethod( string TransactionType, string XML )
		{
			_transactionHandlers[TransactionType].Execute( XML );
		}
	}
