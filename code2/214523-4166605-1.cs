		<System.Diagnostics.DebuggerStepThrough> _
		Public Overrides Function GetPermissionsSystem(ByVal SystemUserName As String) As DataTable
			Try
				Dim oCmd As New SqlCommand
				Dim aDpt As New SqlDataAdapter
				Dim aDst As New DataSet
				Dim theCached As CachedDT
				Dim theCacheName As String = "GetPermissionsSystem|" & SystemUserName
				If cCachedDTs.ContainsKey(theCacheName) Then
					theCached = cCachedDTs.Item(theCacheName)
					If theCached.TheExpirationTime < DateTime.Now Then
						cCachedDTs.Remove(theCacheName)
					Else
						Return theCached.TheDT
					End If
				End If
				With oCmd
					.Connection = MyBase.Conn
					.CommandType = CommandType.StoredProcedure
					.CommandTimeout = MyBase.TimeoutShort
					.CommandText = Invoicing.GetPermissionsSystem
					.Parameters.Add(GP("@SystemUserName", SystemUserName))
				End With
				aDpt.SelectCommand = oCmd
				aDpt.Fill(aDst)
				theCached = New CachedDT
				With theCached
					.TheUniqueIdentifier = theCacheName
					.TheExpirationTime = DateTime.Now.AddSeconds(10)
					.TheDT = aDst.Tables(0)
				End With
				cCachedDTs.Add(theCached.TheUniqueIdentifier, theCached)
				Return aDst.Tables(0)
			Catch sqlex As SqlException
				MyBase.HandelEX(sqlex)
			Catch ex As Exception
				MyBase.HandleEX(ex)
			Finally
				MyBase.CloseConn()
			End Try
		End Function
