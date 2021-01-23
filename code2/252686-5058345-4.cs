        Public Function MatchToUpper(ByVal m As Match) As String
            Return m.Value.ToUpper
        End Function
        Sub Main()
            Dim str As String = "to title case"
            Dim evaluator As MatchEvaluator = AddressOf MatchToUpper
            Console.WriteLine(Regex.Replace(str, "\b[a-z]", evaluator))
            Console.Read()
        End Sub
