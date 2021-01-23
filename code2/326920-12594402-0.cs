	FamilySymbol symbol = GetElements<FamilySymbol>(commandData.Application.ActiveUIDocument.Document)
                              .Where(item => item.Name == "NameYouWant")
                              .First();
	commandData.Application.ActiveUIDocument.PromptForFamilyInstancePlacement(symbol);
		/// <summary>
		/// Get the collection of elements of the specified type.
		/// <para>The specified type must derive from Element, or you can use Element but you get everything :)</para>
		/// </summary>
		/// <typeparam name="T">The type of element to get</typeparam>
		/// <returns>The list of elements of the specified type</returns>
        public IEnumerable<T> GetElements<T>(Document document) where T : Element
        {
            FilteredElementCollector collector = new FilteredElementCollector(document);
            collector.OfClass(typeof(T));
            return collector.Cast<T>();
        }
