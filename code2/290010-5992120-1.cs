    Default Public ReadOnly Item(ByVal index as Integer) As ObjectData
      Get
        If (index = 0) Then
          Throw New ArgumentOutOfRangeException()
        End If
        Return parrObjectData(index)
      End Get
    End Property
