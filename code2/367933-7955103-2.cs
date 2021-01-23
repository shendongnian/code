        ' http://stackoverflow.com/questions/123336/how-can-you-strip-non-ascii-characters-from-a-string-in-c
        Public Shared Function GetAsciiString(ByVal strInputString As String) As String
            Dim strASCII As String = System.Text.Encoding.ASCII.GetString( _
                                                                            System.Text.Encoding.Convert(System.Text.Encoding.UTF8, _
                                                                                                            System.Text.Encoding.GetEncoding(System.Text.Encoding.ASCII.EncodingName, _
                                                                                                            New System.Text.EncoderReplacementFallback(String.Empty), _
                                                                                                            New System.Text.DecoderExceptionFallback()), _
                                                                                                            System.Text.Encoding.UTF8.GetBytes(strInputString) _
                                                                                                        ) _
                                                                        )
            Return strASCII
        End Function
        Public Shared Function IsAscii(ByVal strInputString As String) As Boolean
            'Dim strInputString As String = "Räksmörgås"
            If (GetAsciiString(strInputString) = strInputString) Then
                Return True
            End If
            Return False
        End Function
