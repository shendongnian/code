	Protected Structure CachedDT
		#Region "Local Variables"
		Public TheDT As DataTable
		Public TheExpirationTime As DateTime
		Public TheUniqueIdentifier As String
		#End Region 'Local Variables
	End Structure
    Protected cCachedDTs As Dictionary(Of String, CachedDT) = New Dictionary(Of String, CachedDT)
