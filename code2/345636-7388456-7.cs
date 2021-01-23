		public static Type GetDocumentServiceType<TDto>(IDocumentService<TDto> obj){
			Type tDto=typeof(IDocumentService<TDto>);
			foreach(Type iface in obj.GetType().GetInterfaces()){
				if(tDto.IsAssignableFrom(iface) && !iface.Equals(tDto)){
					return iface;
				}
			}
			return null;
		}
