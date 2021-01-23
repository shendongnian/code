    Function convertotswf(ByVal imgName As String, ByVal iMaxId As Integer) As String
        Dim filename As String
        Dim _mhandler As New MediaHandler()
        
        Dim RootPath As String = System.Configuration.ConfigurationManager.AppSettings("SITE_ROOTPATH")
        
        _mhandler.FFMPEGPath = RootPath + System.Configuration.ConfigurationManager.AppSettings("ffmpegpath")
        _mhandler.InputPath = RootPath + System.Configuration.ConfigurationManager.AppSettings("TEMPVIDEO_ROOTPATH")
        _mhandler.OutputPath = RootPath + System.Configuration.ConfigurationManager.AppSettings("mediapath")
        _mhandler.FileName = imgName
        _mhandler.OutputFileName = iMaxId & ".flv"
        filename = iMaxId & ".flv"
        _mhandler.Video_Bitrate = System.Configuration.ConfigurationManager.AppSettings("flvvideobitrate")
        _mhandler.Audio_Bitrate = System.Configuration.ConfigurationManager.AppSettings("flvaudiobitrate")
        _mhandler.Audio_SamplingRate = System.Configuration.ConfigurationManager.AppSettings("flvsamplingrate")
        Dim info As VideoInfo = _mhandler.Encode_FLV()
        If info.ErrorCode > 0 Then
            If info.ErrorCode = 121 Then
                GoTo read
            End If
            Return "1"
        Else
		read:
            Dim mid_duration As String = System.Configuration.ConfigurationManager.AppSettings("flvmidduration")
            _mhandler.FFMPEGPath = RootPath & System.Configuration.ConfigurationManager.AppSettings("ffmpegpath")
            _mhandler.InputPath = RootPath + System.Configuration.ConfigurationManager.AppSettings("mediapath")
            _mhandler.OutputPath = RootPath + System.Configuration.ConfigurationManager.AppSettings("flvimagepath")
            _mhandler.FileName = filename
            _mhandler.Image_Format = "jpg"
            _mhandler.ImageName = iMaxId & ".jpg"
            _mhandler.Frame_Time = mid_duration
            _mhandler.Width = System.Configuration.ConfigurationManager.AppSettings("flvwidth")
            _mhandler.Height = System.Configuration.ConfigurationManager.AppSettings("flvheight")
            _mhandler.Grab_Thumb()
        End If
        Return filename
    End Function
