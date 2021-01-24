    Public Sub SaveImage()
        Using context = New ProjectDb()
            Dim user = New User() With {
                .Id = Guid.NewGuid,
                .Photo = imageToBytes(PictureBox1.Image)
            }
            context.Users.Add(user)
            context.SaveChanges()
        End Using
    End Sub
