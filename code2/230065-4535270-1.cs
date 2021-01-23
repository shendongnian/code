    For Each item in dictionary.Values
        If dictionary.Count > 0 AndAlso _
            item.Equals(dictionary.Values(dictionary.Count - 1)) Then
            Console.WriteLine("Last Item")
        Else
            Console.WriteLine("Some other Item")
        End If
    Next
