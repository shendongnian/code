	Private Shared Sub Main(args As String())
		Dim questions As List(Of Question) = GetQuestions()
		Dim question As Question = ( _
			Where q.ID = 14 AndAlso _
                  questions.Exists(Function(p) p.ID = 12)).FirstOrDefault()
		If question IsNot Nothing Then
			question.Answer = "Some Text"
		End If
	End Sub
     // Build the collection of questions! We keep this simple.
	Private Shared Function GetQuestions() As List(Of Question)
		Dim questions As New List(Of Question)()
		questions.Add(New Question(12, "foo"))
		questions.Add(New Question(14, "bar"))
		Return questions
	End Function
    // You've already got this class. This one is just my version.
    Public Class Question
    	Public Sub New(id As Integer, answer As String)
    		Me.ID = id
    		Me.Answer = answer
    	End Sub
    	Public Property ID() As Integer
    		Get
    			Return m_ID
    		End Get
    		Set
    			m_ID = Value
    		End Set
    	End Property
    	Private m_ID As Integer
    	Public Property Answer() As String
    		Get
    			Return m_Answer
    		End Get
    		Set
    			m_Answer = Value
    		End Set
    	End Property
    	Private m_Answer As String
    End Class
