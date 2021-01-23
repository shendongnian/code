	Public Function PublicFriendOrPrivate(t As Type) As String
		If t.IsPublic Then
			Return "Public"
		Else
			If t.IsNotPublic AndAlso t.IsNested Then
				Return "Private"
			Else
				Return "Friend"
			End If
		End If
	End Function
