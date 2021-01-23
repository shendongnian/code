     Public Function ExceptionToString(ByVal Message As String, ByVal ex As Exception) As String
            Dim Splitter As String = "-------------------------------------------------------------------"
            Dim ex0 As String = Message & vbCrLf & Splitter & vbCrLf
            Dim ex1 As String = ""
            Dim ex2 As String = ""
            Dim ex3 As String = ""
            Dim ex4 As String = ""
            Dim ex5 As String = ""
            Try
                ex1 = ex.Message & vbCrLf & Splitter & vbCrLf
            Catch exc1 As Exception
            End Try
            Try
                ex2 = ex.StackTrace & vbCrLf & Splitter & vbCrLf
            Catch exc1 As Exception
            End Try
            Try
                ex3 = ex.InnerException.Message & vbCrLf & Splitter & vbCrLf
            Catch exc1 As Exception
            End Try
            Try
                ex4 = ex.InnerException.StackTrace & vbCrLf & Splitter & vbCrLf
            Catch exc1 As Exception
            End Try
            Try
                Dim DataStr As String = ""
                For i As Integer = 0 To ex.Data.Keys.Count
                    Try
                        DataStr &= ex.Data.Item(ex.Data.Keys(i)) & vbCrLf
                    Catch exc2 As Exception
                    End Try
                Next
                ex5 = DataStr & vbCrLf & Splitter & vbCrLf
            Catch exc1 As Exception
            End Try
    
            Dim Result As String = ex0 & ex1 & ex2 & ex3 & ex4 & ex5
    
            Return Result
    
        End Function
