		Public Sub DoWork(obj As CustomObject)
			Dim linq = (From s In storages Where s.Key = obj.Keys.Value).ToList()
			Dim act As Action(Of ICustomService) = Function(service As ICustomService) Do
				service.ChangeValue(obj)
			End Function
			linq.ForEach(act)
		End Sub
 
