		public static IDocumentService<TDto> GetDocumentService<TDto>()
		{
			// Gets the type for IDocumentService
			Type tDto=typeof(IDocumentService<TDto>);
			Type tConcrete=null;
			foreach(Type t in Assembly.GetCallingAssembly().GetTypes()){
				// Find a type that implements tDto and is concrete.
				// Assumes that the type is found in the calling assembly.
				if(tDto.IsAssignableFrom(t) && !t.IsAbstract && !t.IsInterface){
					tConcrete=t;
					break;
				}
			}
			// Create an instance of the concrete type
			object o=Activator.CreateInstance(tConcrete);
			return (IDocumentService<TDto>)o;
		}
