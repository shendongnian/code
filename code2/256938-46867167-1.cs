   	Public Class ReconcileEnumerationConverter : Inherits JsonConverter
		Public Overrides Function CanConvert(objectType As Type) As Boolean
			'check to ensure our target type has the necessary interfaces
			Return GetType(IList).IsAssignableFrom(objectType) AndAlso GetType(IEnumerable(Of IEquatable(Of JToken))).IsAssignableFrom(objectType)
		End Function
		Public Overrides ReadOnly Property CanWrite As Boolean
			Get
				Return False
			End Get
		End Property
		Public Overrides Function ReadJson(reader As JsonReader, objectType As Type, existingValue As Object, serializer As JsonSerializer) As Object
			Dim array As JArray = JArray.ReadFrom(reader)
			'cast the existing items
			Dim existingItems As IEnumerable(Of IEquatable(Of JToken)) = CType(existingValue, IEnumerable(Of IEquatable(Of JToken)))
			'copy the existing items for reconcilliation (removal) purposes
			Dim unvisitedItems As IList = existingItems.ToList 'start with full list, and remove as we go
			'iterate each item in the json array
			For Each j As JToken In array.Children
				'look for existing
				Dim existingitem As Object = existingItems.FirstOrDefault(Function(x) x.Equals(j))
				If existingitem IsNot Nothing Then 'found an existing item, update it
					JsonSerializer.CreateDefault.Populate(j.CreateReader, existingitem)
					unvisitedItems.Remove(existingitem)
				Else 'create a new one
					Dim newItem As Object = JsonSerializer.CreateDefault.Deserialize(j.CreateReader)
					CType(existingItems, IList).Add(newItem)
				End If
			Next
			'remove any items not visited
			For Each item As Object In unvisitedItems
				CType(existingItems, IList).Remove(item)
			Next
			Return existingItems
		End Function
		Public Overrides Sub WriteJson(writer As JsonWriter, value As Object, serializer As JsonSerializer)
			Throw New NotImplementedException
		End Sub
	End Class
