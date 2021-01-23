    Private m_Comments As ICollection(Of Comment)
    Public Overridable Property Comments() As ICollection(Of Comment)
        Get
            Return m_Comments
        End Get
        Set(ByVal value As ICollection(Of Comment))
            m_Comments = value
        End Set
    End Property
