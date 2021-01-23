    Public Property IsSelected() As Boolean
        Get
            Return m_IsSelected
        End Get
        Set(ByVal value As Boolean)
            m_IsSelected = value
            OnPropertyChanged("IsSelected")
        End Set
    End Property
