    Public Class Form1
    Friend WithEvents dTextbox1 As dTextbox
    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.dTextbox1 = New dTextbox()
        Me.dTextbox1.Location = New System.Drawing.Point(278, 122)
        Me.dTextbox1.Name = "dTextBox1"
        Me.dTextbox1.Size = New System.Drawing.Size(79, 20)
        Me.dTextbox1.TabIndex = 2
        Me.dTextbox1.Visible = True
        Me.Controls.Add(Me.dTextbox1)
    End Sub
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        MsgBox(CStr(dTextbox1.Value))
    End Sub
    End Class
    Class dTextbox
    Inherits TextBox
    Friend Value As Double
    Dim DecimalWasEntered As Boolean
    Dim DecimalPlaces As Integer
    Dim ChangedByProgram As Boolean
    Dim KeyAlreadyHandled As Boolean
    Sub New()
        Value = 0
        DecimalWasEntered = False
        DecimalPlaces = 0
        ChangedByProgram = False
        KeyAlreadyHandled = False
    End Sub
    Private Sub dTextbox_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        ChangedByProgram = False
        If KeyAlreadyHandled Then
            e.Handled = True
        ElseIf e.KeyChar = "." Then
            DecimalWasEntered = True
            e.Handled = True
            DisplayText()
        ElseIf DecimalWasEntered Then
            DecimalPlaces += 1
            If DecimalPlaces > 2 Then DecimalPlaces = 2
        End If
    End Sub
    Private Sub dTextbox_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Dim MeTextInProgress As String
        KeyAlreadyHandled = False
        If e.KeyCode = Keys.Delete Or e.KeyCode = Keys.Back Then
            MeTextInProgress = Text
            If SelectionLength = MeTextInProgress.Length() Then
                DecimalWasEntered = False
                DecimalPlaces = 0
                Value = 0
            ElseIf SelectionLength > 0 Then
                MeTextInProgress = MeTextInProgress.Remove(SelectionStart, SelectionLength)
                ConvertToDouble(MeTextInProgress)
            Else
                If Not DecimalWasEntered Then
                    MeTextInProgress = MeTextInProgress.Remove(MeTextInProgress.Length() - 4, 1)
                Else
                    MeTextInProgress = MeTextInProgress.Substring(0, Text.Length() - 3 + DecimalPlaces)
                    DecimalPlaces -= 1
                    If DecimalPlaces = 0 Then DecimalWasEntered = False
                End If
                ConvertToDouble(MeTextInProgress)
            End If
            DisplayText()
            e.Handled = True
            KeyAlreadyHandled = True
        End If
    End Sub
    Private Sub TextBox2_TextChanged(sender As System.Object, e As System.EventArgs) Handles Me.TextChanged
        If ChangedByProgram Then Exit Sub
        ConvertToDouble(Text)
        DisplayText()
    End Sub
    Sub ConvertToDouble(t As String)
        Dim d As Double
        Try
            d = CDbl(t)
            Me.Value = d
        Catch ex As Exception
            Beep()
        End Try
    End Sub
    Sub DisplayText()
        ChangedByProgram = True
        Me.Text = Me.Value.ToString("#,##0.00")
        If DecimalWasEntered Then
            Me.SelectionStart = Me.Text.Length() - 2 + DecimalPlaces
        Else
            Me.SelectionStart = Me.Text.Length() - 3
        End If
    End Sub
    End Class
