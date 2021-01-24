    Public Function GetImage(ByVal id As Guid) As Image
        Using context = New ProjectDb()
            Dim image As Image
            Dim user As User = context.Users.FirstOrDefault(Function(x) x.Id = id)
            If user IsNot Nothing Then
                image = bytesToImage(user.Photo)
                PictureBox2.Image = image
            End If
        End Using
    End Function
