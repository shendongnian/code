     Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
				. . .
				If IsPostBack Then
					' A postback
					Dim dataURL As String
					Dim photo As System.Web.Helpers.WebImage
					photo = System.Web.Helpers.WebImage.GetImageFromRequest()
					If (photo IsNot Nothing) Then
						Dim imagebase64string As String
						imagebase64string = Convert.ToBase64String(photo.GetBytes())
						dataURL = String.Format("data:image/jpeg;base64,{0}", imagebase64string)
						UploadedImage.Src = dataURL
					End If
	
    			. . .
       End Sub
