      Public Function getImage(ByVal input As String) As String
        If input Is Nothing Then
            Return String.Empty
        End If
        Dim tempInput As String = input
        Dim pattern As String = "<IMG(.|)+?>"
        Dim src As String = String.Empty
        Dim context As HttpContext = HttpContext.Current
        'Change the relative URL's to absolute URL's for an image, if any in the HTML code. 
        For Each m As Match In Regex.Matches(input, pattern, RegexOptions.IgnoreCase Or RegexOptions.Multiline Or RegexOptions.RightToLeft)
            If m.Success Then
                Dim tempM As String = m.Value
                Dim pattern1 As String = "src=['|""](.+?)['|""]"
                Dim reImg As New Regex(pattern1, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
                Dim mImg As Match = reImg.Match(m.Value)
                If mImg.Success Then
                    src = mImg.Value.ToLower().Replace("src=", "").Replace("""", "")
                    If src.ToLower().Contains("http://") = False Then
                        'IIf you want to access through you can use commented src line below 
                        '   src = "src=\"" + context.Request.Url.Scheme + "://" + context.Request.Url.Authority + "/" + src + "\"";
                        src = "src=""" & Server.MapPath("~") & "\" & src & """"
                        Try
                            tempM = tempM.Remove(mImg.Index, mImg.Length)
                            tempM = tempM.Insert(mImg.Index, src)
                            'insert new url img tag in whole html code 
                            tempInput = tempInput.Remove(m.Index, m.Length)
                            tempInput = tempInput.Insert(m.Index, tempM)
                        Catch e As Exception
                        End Try
                    End If
                End If
            End If
        Next
        Return tempInput
    End Function
