    Namespace Diagnostics
    
    	<Conditional("DEBUG")> _
    	Public NotInheritable Class UniqueID
    
    		Private Shared _idBase As Integer
    
    		Private Sub New()
    			'keep compiler from creating default constructor
    		End Sub
    
    		Public Shared Function GetNext() As String
    			Return "ID" + System.Threading.Interlocked.Increment(_idBase).ToString("00")
    		End Function
    
    	End Class
        
    End Namespace
