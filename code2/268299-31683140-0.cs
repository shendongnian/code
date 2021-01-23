    Private m_tobj As TAPIClass
    Private m_array_ITAdresses(10) As ITAddress
    Private m_bcc As ITBasicCallControl
    Public Sub New()
        initializetapi3()
    End Sub
    Dim m_nIPPHONEline As Integer
    Dim m_nGetIPPhoneLineNumber As Integer
    Public Sub initializetapi3()
        Try
            For Each ob1 As ITAddress In m_array_ITAdresses
            Next
            m_tobj = New TAPIClass()
            m_tobj.Initialize()
            Dim ea As IEnumAddress = m_tobj.EnumerateAddresses()
            Dim ln As ITAddress
            Dim arg3 As UInteger = 0
            m_nGetIPPhoneLineNumber = -1 'Must initialze to -1 because the phone lines start counting from zero.
            m_nIPPHONEline = -1
            'm_tobj.EventFilter = DirectCast(TAPI_EVENT.TE_CALLNOTIFICATION | TAPI_EVENT.TE_DIGITEVENT |TAPI_EVENT.TE_PHONEEVENT |TAPI_EVENT.TE_CALLSTATE |TAPI_EVENT.TE_GENERATEEVENT |TAPI_EVENT.TE_GATHERDIGITS | TAPI_EVENT.TE_REQUEST, integer) 
            For i As Integer = 0 To 10
                ea.Next(1, ln, arg3)
                m_array_ITAdresses(i) = ln
                If (ln Is Nothing) = False Then
                    m_nGetIPPhoneLineNumber += 1
                    If m_array_ITAdresses(i).AddressName.ToUpper().IndexOf("IP PHONE") > -1 Then
                        m_nIPPHONEline = m_nGetIPPhoneLineNumber
                    End If
                End If
            Next
        Catch ex As Exception
        End Try
    End Sub
    Public Sub MakeCall(ByVal stPhoneNumber As String)
        If stPhoneNumber.Length > 6 Then
            Try
                m_bcc = m_array_ITAdresses(m_nIPPHONEline).CreateCall(stPhoneNumber, TapiConstants.LINEADDRESSTYPE_IPADDRESS, TapiConstants.TAPIMEDIATYPE_AUDIO)
                m_bcc.Connect(False)
            Catch ex As Exception
                MessageBox.Show("Failed to create call.")
            End Try
        End If
        m_tobj.Shutdown()
    End Sub
