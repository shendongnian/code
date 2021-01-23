    Public Sub DoWork(ByVal obj As CustomObject)
        Dim values = (From s In storages
                     Where s.Key = obj.Key
                     Select s.Value).ToList()
        values.ForEach(Sub(service As ICustomService) service.ChangeValue(obj))
    End Sub
