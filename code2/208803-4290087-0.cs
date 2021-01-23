            Dim username As String = "default"
            Dim query As AlbumQuery = New AlbumQuery(PicasaQuery.CreatePicasaUri(username))
            Dim feed As PicasaFeed = service.Query(query)
            Dim albums As New List(Of MyAlbum)
            For Each entry As PicasaEntry In feed.Entries
                Dim ac As AlbumAccessor = New AlbumAccessor(entry)
                Dim a As MyAlbum
                a.Name = ac.AlbumTitle
                a.ImageCount = ac.NumPhotos
                a.ID = ac.Id
                albums.Add(a)
            Next
