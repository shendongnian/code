    '---------------------------------------------------------------------------------------'
    ' Procedure : Pluralize'
    ' Purpose   : Formats an English phrase to make verbs agree in number.'
    ' Usage     : Msg = "There [is/are] # record[s].  [It/They] consist[s/] of # part[y/ies] each."'
    '             Pluralize(Msg, 1) --> "There is 1 record.  It consists of 1 party each."'
    '             Pluralize(Msg, 6) --> "There are 6 records.  They consist of 6 parties each."'
    '---------------------------------------------------------------------------------------'
    ''
    Function Pluralize(Text As String, Num As Variant, Optional NumToken As String = "#")
    Const OpeningBracket = "\["
    Const ClosingBracket = "\]"
    Const DividingSlash = "/"
    Const CharGroup = "([^\]]*)"  'Group of 0 or more characters not equal to closing bracket'
    Dim IsPlural As Boolean, Msg As String, Pattern As String
        
        On Error GoTo Err_Pluralize
    
        If IsNumeric(Num) Then
            IsPlural = (Num <> 1)
        End If
        
        Msg = Text
        
        'Replace the number token with the actual number'
        Msg = Replace(Msg, NumToken, Num)
        
        'Replace [y/ies] style references'
        Pattern = OpeningBracket & CharGroup & DividingSlash & CharGroup & ClosingBracket
        Msg = RegExReplace(Pattern, Msg, "$" & IIf(IsPlural, 2, 1))
        
        'Replace [s] style references'
        Pattern = OpeningBracket & CharGroup & ClosingBracket
        Msg = RegExReplace(Pattern, Msg, IIf(IsPlural, "$1", ""))
        
        'Return the modified message'    
        Pluralize = Msg
    End Function
    Function RegExReplace(SearchPattern As String, _
                          TextToSearch As String, _
                          ReplacePattern As String) As String
    Dim RE As Object
    
        Set RE = CreateObject("vbscript.regexp")
        With RE
            .MultiLine = False
            .Global = True
            .IgnoreCase = False
            .Pattern = SearchPattern
        End With
        
        RegExReplace = RE.Replace(TextToSearch, ReplacePattern)
    End Function
    
