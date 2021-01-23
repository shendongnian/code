       Public Property CustomerName() As String
            Get
                Return Me.customerNameValue
            End Get
    
            Set(ByVal value As String)
                If Not (value = customerNameValue) Then
                    Me.customerNameValue = value
                    NotifyPropertyChanged("CustomerName")
                End If
            End Set
        End Property
