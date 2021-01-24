	public abstract class CacheableViewForm: Form
	{
		static Dictionary<Type, Func<CacheableViewForm>> CacheableViewFormConstructors = new Dictionary<Type, Func<CacheableViewForm>>();
		
		static CacheableViewForm()
		{
			var allAssemblies = AppDomain.CurrentDomain.GetAssemblies();
			
			foreach(Assembly assembly in allAssemblies)
			{
				Type[] CacheableViewFormTypes = assembly.GetExportedTypes().Where(t => typeof(CacheableViewForm).IsAssignableFrom(t) && t != typeof(CacheableViewForm)).ToArray();
				
				foreach (Type CacheableViewFormType in CacheableViewFormTypes)
				{
					MethodInfo mi = CacheableViewFormType.GetMethod("TargetType");
					Type cacheableType = (Type)mi.Invoke(null, null);
					Func<CacheableViewForm> ctorDelegate = (() => (CacheableViewForm)(Activator.CreateInstance(CacheableViewFormType)));
		        	CacheableViewFormConstructors[cacheableType] = ctorDelegate;
				}
			}
		}
		public static CacheableViewForm CreateFromTargetType(Type cacheableType)
		{
			return CacheableViewFormConstructors[cacheableType]();
		}
	}
	
	public class SeriesViewForm: CacheableViewForm
	{
		public static Type TargetType() {return typeof(Series);}
		// ...
	}
