    Dim strings = New String() {"A", "B", "C"}
    ' Notice I am passing only one type argument. '
    Dim objects = strings.Append(Of Integer)()
    For Each obj As Object In objects
        Console.WriteLine(obj)
    Next
