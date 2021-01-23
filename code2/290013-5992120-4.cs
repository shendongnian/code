    Private Class CollectionWrapper
      Implements ICollection(Of ObjectData)
    
      Private m_Collection As ICollection(Of ObjectData)
    
      Public Sub New(ByVal collection As ICollection(Of ObjectData))
        m_Collection = collection
      End Sub
    
      Default Public ReadOnly Item(ByVal index as Integer) As ObjectData
        Get
          If (index = 0) Then
            Throw New ArgumentOutOfRangeException()
          End If
          Return m_Collection(index)
        End Get
      End Property
    
    End Class
