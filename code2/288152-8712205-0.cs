    Dim WithEvents sre As SpeechRecognitionEngine
    Private Sub btnLiterate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLiterate.Click
        If TextBox1.Text.Trim.Length = 0 Then Exit Sub
        sre.SetInputToWaveFile(TextBox1.Text)
        Dim r As RecognitionResult
        r = sre.Recognize()
        If r Is Nothing Then
            TextBox2.Text = "Could not fetch result"
            Return
        End If
        TextBox2.Text = r.Text
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        TextBox1.Text = String.Empty
        Dim dr As DialogResult
        dr = OpenFileDialog1.ShowDialog()
        If dr = Windows.Forms.DialogResult.OK Then
            If Not OpenFileDialog1.FileName.Contains("wav") Then
                MessageBox.Show("Incorrect file")
            Else
                TextBox1.Text = OpenFileDialog1.FileName
            End If
        End If
    End Sub
    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        sre = New SpeechRecognitionEngine()
    End Sub
    Private Sub sre_LoadGrammarCompleted(ByVal sender As Object, ByVal e As System.Speech.Recognition.LoadGrammarCompletedEventArgs) Handles sre.LoadGrammarCompleted
    End Sub
    Private Sub sre_SpeechHypothesized(ByVal sender As Object, ByVal e As System.Speech.Recognition.SpeechHypothesizedEventArgs) Handles sre.SpeechHypothesized
        System.Diagnostics.Debug.Print(e.Result.Text)
    End Sub
    Private Sub sre_SpeechRecognitionRejected(ByVal sender As Object, ByVal e As System.Speech.Recognition.SpeechRecognitionRejectedEventArgs) Handles sre.SpeechRecognitionRejected
        System.Diagnostics.Debug.Print("Rejected: " & e.Result.Text)
    End Sub
    Private Sub sre_SpeechRecognized(ByVal sender As Object, ByVal e As System.Speech.Recognition.SpeechRecognizedEventArgs) Handles sre.SpeechRecognized
        System.Diagnostics.Debug.Print(e.Result.Text)
    End Sub
    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim words As String() = New String() {"triskaidekaphobia"}
        Dim c As New Choices(words)
        Dim grmb As New GrammarBuilder(c)
        Dim grm As Grammar = New Grammar(grmb)
        sre.LoadGrammar(grm)
    End Sub
