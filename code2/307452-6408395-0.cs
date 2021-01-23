        Dim bigString As String = "helloworld.thisisastackoverflowtest!"
    
        Dim dictionary As New List(Of String) 'contains the original words. lets make it case insentitive
        dictionary.Add("Hello")
        dictionary.Add("World")
        dictionary.Add("this")
        dictionary.Add("is")
        dictionary.Add("a")
        dictionary.Add("stack")
        dictionary.Add("over")
        dictionary.Add("flow")
        dictionary.Add("stackoverflow")
        dictionary.Add("test")
        dictionary.Add("!")
    
    
        For Each word As String In dictionary
            If word.Length < 1 Then dictionary.Remove(word) 'remove short words (will not work with for each in real)
            word = word.ToLower 'make it case insentitive
        Next
    
        Dim ResultComparer As New Dictionary(Of String, Double) 'String is the dictionary word. Double is a value as percent for a own function to weight result
    
        Dim i As Integer = 0 'start at the beginning
        Dim Found As Boolean = False
        Do
            For Each word In dictionary
                If bigString.IndexOf(word, i) > 0 Then
                    ResultComparer.Add(word, MyWeightOfWord) 'add the word if found, long words are better and will increase the weight value 
                    Found = True
                End If
            Next
            If Found = True Then
                i += ResultComparer(BestWordWithBestWeight).Length
            Else
                i += 1
            End If
        Loop
    
