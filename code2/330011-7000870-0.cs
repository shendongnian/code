       Dim b2 As New Binding("sFileLocation")
       b2.Mode = BindingMode.TwoWay
       b2.Source = DirectCast(q, QuestionListClass.QuestionsFile)
       b2.Converter = New ViewButtonConverter
       btn2.SetBinding(Button.VisibilityProperty, b2)
