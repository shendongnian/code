        Using Reader As New Microsoft.VisualBasic.FileIO.TextFieldParser(CSVPath)
            Reader.TextFieldType = Microsoft.VisualBasic.FileIO.FieldType.Delimited
            Reader.Delimiters = New String() {","}
            Reader.TrimWhiteSpace = True
            Reader.HasFieldsEnclosedInQuotes = True
            While Not Reader.EndOfData
                Try
                    Dim st2 As New List(Of String)
                    st2.addrange(Reader.ReadFields())
                    If iCount > 0 Then ' ignore first row = field names
                        Dim p As New Person
                        p.CSVLine = st2
                        p.FirstName = st2(1).Trim
                        If st2.Count > 2 Then
                            p.MiddleName = st2(2).Trim
                        Else
                            p.MiddleName = ""
                        End If
                        p.LastNameSuffix = st2(0).Trim
                        If st2.Count >= 5 Then
                            p.TestCase = st2(5).Trim
                        End If
                        If st2(3) > "" Then
                            p.AccountNumbersFromCase.Add(st2(3))
                        End If
                        While p.CSVLine.Count < 15
                            p.CSVLine.Add("")
                        End While
                        cases.Add(p)
                    End If
                Catch ex As Microsoft.VisualBasic.FileIO.MalformedLineException
                    MsgBox("Line " & ex.Message & " is not valid and will be skipped.")
                End Try
                iCount += 1
            End While
        End Using
