    Module Module1
        Private m_MyForm As Form1
        Public ReadOnly Property MyForm() As Form1
            Get
                If IsNothing(m_MyForm) Then m_MyForm = New Form1
                Return m_MyForm
            End Get
        End Property
        Public Sub WriteLog(ByVal txt As String)
            MyForm.TextBox3.Text += txt + vbNewLine
        End Sub
    End Module
