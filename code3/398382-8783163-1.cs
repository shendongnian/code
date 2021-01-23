    Private m_fOkToUpdateAutoComplete As Boolean
    Private m_sLastSearchedFor As String = ""
    Private Sub cboName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles m_cboName.KeyDown
        Try
            ' Catch up and down arrows, and don't change text box if these keys are pressed.
            If e.KeyCode = Keys.Up OrElse e.KeyCode = Keys.Down Then
                m_fOkToUpdateAutoComplete = False
            Else
                m_fOkToUpdateAutoComplete = True
            End If
        Catch theException As Exception
            ' Do something with the exception
        End Try
    End Sub
    Private Sub cboName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_cboName.TextChanged
        Try
            If m_fOkToUpdateAutoComplete Then
                With m_cboName
                    If .Text.Length >= 4 Then
                        ' Only do a search when the first 4 characters have changed
                        If Not .Text.Substring(0, 4).Equals(m_sLastSearchedFor, StringComparison.InvariantCultureIgnoreCase) Then
                            Dim cSuggestions As StringCollection
                            Dim sError As String = ""
                            ' Record the last 4 characters we searched for
                            m_sLastSearchedFor = .Text.Substring(0, 4)
                            ' And search for those
                            ' Retrieve the suggestions from the database using like statements
                            cSuggestions = GetSuggestions(m_sLastSearchedFor, sError)
                            If cSuggestions IsNot Nothing Then
                                m_cboName.DataSource = cSuggestions
                                ' Let the list catch up. May need to do Thread.Idle here too
                                Application.DoEvents()
                            End If
                        End If
                    Else
                        If Not String.IsNullOrEmpty(m_sLastSearchedFor) Then
                            ' Clear the last searched for text
                            m_sLastSearchedFor = ""
                            m_cboName.DataSource = Nothing
                        End If
                    End If
                End With
            End If
        Catch theException As Exception
            ' Do something with the exception
        End Try
    End Sub
