    Friend Class CompilerUtils
    #If HideCode Then
        Public Const Browsable As EditorBrowsableState = EditorBrowsableState.Never 
        Public Const BrowsableAdvanced As EditorBrowsableState = EditorBrowsableState.Never 
    #Else
        Public Const Browsable As EditorBrowsableState = EditorBrowsableState.Always
        Public Const BrowsableAdvanced As EditorBrowsableState = EditorBrowsableState.Advanced
    #End If
    End Class
