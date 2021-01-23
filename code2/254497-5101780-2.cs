    Sub buttons(ByVal sender As Object, ByVal e As ListViewCommandEventArgs) Handles LVCategories.ItemCommand
            Try
                Select Case e.CommandName
    
                    Case "Delete"
                        'this to take a value from any control
                        Dim Idlabel As Label = e.Item.FindControl("CatIDLabel")
                        Session("ID") = Idlabel.Text()
                    Case "new"
                        'Show the insert template
                        LVCategories.InsertItemPosition = InsertItemPosition.FirstItem
                    Case "Cancel"
                        'Hide code
                        LVCategories.InsertItemPosition = InsertItemPosition.None
    
                    Case "Edit"
                        'Hide code
                        LVCategories.InsertItemPosition = InsertItemPosition.None
    
                    Case "Update"
                        Dim PictureIDlbl As Label = LVCategories.EditItem.FindControl("ImageIDLabel")
                        '
                        Dim fu As FileUpload = LVCategories.EditItem.FindControl("FileUpload")
                        If fu.HasFile Then
    
                            Dim PictureID As String = PictureIDlbl.Text()
                            Session("ImageID") = PictureID.ToString
    
                            Dim filepath As String = Path.Combine(Server.MapPath("~/ADMIN/ImageUpload/Categories/"), PictureID + ".jpg")
                            fu.SaveAs(filepath)
                        End If
                    Case "Insert"
                        'Uploader Code
                        Dim fu As FileUpload = LVCategories.InsertItem.FindControl("FileUpload1")
                        Dim ad As New Images()
                        Dim dt As Images.ImagesDataTable
                        ad.DML("1", Nothing, "Categories", "Category Image")
                        dt = ad.Read("3", Nothing, Nothing)
                        Dim DR As DataRow = dt.Rows(0)
                        Dim Imgid As String = DR.Item("ImageID")
                        Session("ImageID") = Imgid.ToString
                        If fu.HasFile Then
                            Dim filepath As String = Path.Combine(Server.MapPath("~/ADMIN/ImageUpload/Categories/"), Imgid + ".jpg")
                            fu.SaveAs(filepath)
                        End If
                        'Hiding the insert template
                        LVCategories.InsertItemPosition = InsertItemPosition.None
                End Select
    
            Catch ex As Exception
    
            End Try
    
    
        End Sub
