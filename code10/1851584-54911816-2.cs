Imports System.Text.Encoding
Module Module1
    'Abstract base class to represent all string types (Normal and Base64 etc)
    MustInherit Class AnyString
        Private str As String
        Public Sub New(s As String)
            Me.str = s
        End Sub
        Public Overrides Function ToString() As String
            Return str
        End Function
        ' Allow implicit conversion of a System.String to NormalString, which inherits from AnyString
        Shared Widening Operator CType(ByVal s As String) As AnyString
            Return New NormalString(s)
        End Operator
    End Class
    'Class for Base64 strings only.
    Class Base64String
        Inherits AnyString
        Public Sub New(s As String)
            MyBase.New(s)
        End Sub
    End Class
    'Class for Normal strings. System.String implicitly converts to this.
    Class NormalString
        Inherits AnyString
        Public Sub New(s As String)
            MyBase.New(s)
        End Sub
        ' Allow implicit conversion of a System.String to NormalString
        ' This CType Operator isn't strictly necessary for this example, 
        ' because the CType in AnyString does the implict conversion shown below, 
        ' but it might be useful in general.
        Shared Widening Operator CType(ByVal s As String) As NormalString
            Return New NormalString(s)
        End Operator
    End Class
    'Function that Accepts Base64String OR Normal String
    Sub TestAny(s As AnyString)
        'Call ToString for whatever type of string was passed.
        Console.WriteLine(s.GetType().Name.ToString()  & ": " & s.ToString())
        
        'Also do something special for base64 string
        If TypeOf s Is Base64String then
            Console.WriteLine("Base64 Decoded (in TestAny): " & DecodeBase64(DirectCast(s,Base64String)))
        End If
    End Sub
    ' Function to convert Base64-encoded string to normal text. 
    ' This ONLY takes Base64Strings (not NormalStrings)
    Function DecodeBase64(s64 As Base64String) As String
        Return UTF8.GetString(System.Convert.FromBase64String(s64.ToString()))
    End Function
    Sub Main()
        'Normal String
        Dim s As new System.String("I am Normal")
        ' Base64String
        Dim s64 As New Base64String("SGVsbG8gV29ybGQh")
        'Call TestAny with any type of string
        TestAny("Hi") 'Call with string directly
        TestAny(s)    'Call with String object
        TestAny(s64)  'Call with Base64DotBase64
        'Call DecodeBase64 with a Base64String ONLY
        Console.Write("Base64-Decoded (in Main): ")
        Console.WriteLine(DecodeBase64(s64))   'OK call with Base64String
        'Console.WriteLine(DecodeBase64("Hi"))  !!! Invalid -- cannot call DecodeBase64 with string
        'Console.WriteLine(DecodeBase64(s))     !!! Invalid -- cannot call DecodeBase64 with string
        ' Pause to see the screen
        Console.ReadKey()
    End Sub
End Module
Expected Output:
