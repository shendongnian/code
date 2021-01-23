		public static class CollectionEx
		{
		  /// <summary>
		  /// Copies the contents of an IEnumerable list to an ObservableCollection
		  /// </summary>
		  /// <typeparam name="T">The type of objects in the source list</typeparam>
		  /// <param name="enumerableList">The source list to be converted</param>
		  /// <returns>An ObservableCollection containing the objects from the source list</returns>
		  public static ObservableCollection<T> ToObservableCollection<T>( this IEnumerable<T> enumerableList )
		  {
		    if( enumerableList != null ) {
		      // Create an emtpy observable collection object
		      var observableCollection = new ObservableCollection<T>();
		
		      // Loop through all the records and add to observable collection object
		      foreach( var item in enumerableList ) {
		        observableCollection.Add( item );
		      }
		
		      // Return the populated observable collection
		      return observableCollection;
		    }
		    return null;
		  }
		}
