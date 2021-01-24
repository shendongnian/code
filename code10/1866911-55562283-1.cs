    Private _persister As PageStatePersister = Nothing
    Protected Overrides ReadOnly Property PageStatePersister As PageStatePersister
        Get
            If _persister Is Nothing Then
                _persister = New SessionPageStatePersister(Me)
            End If
            Return _persister
        End Get
    End Property
