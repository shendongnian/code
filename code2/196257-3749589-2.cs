    Imports System.Globalization
    Module Module1
    Sub Main()
        Dim enUS As New CultureInfo("en-US")
        Dim d As String = Format(DateTime.Now, "yyyy-MM-dd_hh-mm-ss")
        Dim da As Date = DateTime.ParseExact(d, "yyyy-MM-dd_hh-mm-ss", enUS)
        Console.WriteLine("Date from filename: {0}", d)
        Console.WriteLine("Date formated as date: {0}", Format(da, "dd.MM.yyyy HH:mm:ss"))
    End Sub
    End Module
