	// Enum for element type. The order matters, it's the order in which input dictionary is tested.
	enum eElement
	{
		DataConnection,
		FormParameter,
	}
	// Custom attribute to mark bindings classes with.
	class DataBindingAttribute : Attribute
	{
		public eElement element;
		public DataBindingAttribute( eElement e ) { element = e; }
	}
	// Base class for bindings
	abstract class BindingBase { }
	// Couple test binding classes
	[DataBinding( eElement.DataConnection )]
	class DataConnectionPropertyDataBinding: BindingBase
	{
		public DataConnectionPropertyDataBinding( object data ) { }
	}
	[DataBinding( eElement.FormParameter )]
	class FormParameterDataBinding: BindingBase
	{
		public readonly object data;
		public FormParameterDataBinding( object data ) { this.data = data; }
	}
	// This static class does the magic.
	static class BindingsFactory
	{
		// Key = eElement from custom attribute, value = function that constructs the binding. This example uses the constructor with single object argument.
		// It's a good idea to use strong types for arguments instead.
		static readonly SortedDictionary<eElement, Func<object, BindingBase>> dictTypes = new SortedDictionary<eElement, Func<object, BindingBase>>();
		static BindingsFactory()
		{
			// Constructor argument types, just a single `object` in this example.
			Type[] constructorArgumentTypes = new Type[ 1 ]
			{
				typeof( object )
			};
			ParameterExpression[] constructorArgumentExpressions = constructorArgumentTypes
				.Select( tp => Expression.Parameter( tp ) )
				.ToArray();
			// Find all types in current assembly
			var ass = Assembly.GetExecutingAssembly();
			foreach( Type tp in ass.GetTypes() )
			{
				// Try to get the custom attribute
				var dba = tp.GetCustomAttribute<DataBindingAttribute>();
				if( null == dba )
					continue;
				// Ensure you don't have 2 classes with the same element ID value
				Debug.Assert( !dictTypes.ContainsKey( dba.element ) );
				// Ensure the found type inherits from BindingBase
				Debug.Assert( typeof( BindingBase ).IsAssignableFrom( tp ) );
				// Compile the function that constructs the new binding object
				ConstructorInfo ci = tp.GetConstructor( constructorArgumentTypes );
				Debug.Assert( null != ci );
				// new Binding(...)
				var expNew = Expression.New( ci, constructorArgumentExpressions );
				// (BindingBase)( new Binding( ... ) )
				var expCast = Expression.Convert( expNew, typeof( BindingBase ) ); 
				// Compile into lambda
				var lambda = Expression.Lambda<Func<object, BindingBase>>( expCast, constructorArgumentExpressions );
				// Compile the lambda, and save in the sorted dictionary
				var func = lambda.Compile();
				dictTypes.Add( dba.element, func );
			}
		}
		public static BindingBase tryConstruct( Dictionary<eElement, object> dict )
		{
			foreach( var kvp in dictTypes )
			{
				object arg;
				if( !dict.TryGetValue( kvp.Key, out arg ) )
					continue;
				return kvp.Value( arg );
			}
			return null;
		}
	}
	class Program
	{
		static void Main( string[] args )
		{
			var dict = new Dictionary<eElement, object>();
			dict[ eElement.FormParameter ] = 12;
			// This line will construct an instance of FormParameterDataBinding
			var res = BindingsFactory.tryConstruct( dict );
		}
	}
