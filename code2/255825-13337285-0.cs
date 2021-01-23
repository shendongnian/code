     Public Overridable Property Comments() As ICollection(Of Comment)
	     Get
		Return m_Comments
   	    End Get
	     Set
		m_Comments = Value
	    End Set
     End Property
     Private Overridable m_Comments As ICollection(Of Comment)
