    Public Sub DoWork(ByVal obj As CustomObject)
        Dim linq = storage.Where(Function(s) s.Key = obj.Key).[Select](Function(s) s.Value).ToList()
        Dim act As Action(Of ICustomService) = Sub(service As ICustomService)
                                                   service.ChangeValue(obj)
                                               End Sub
        linq.ForEach(act)
    End Sub
