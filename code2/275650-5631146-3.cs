    Private sw As Stopwatch
    Private Sub FirstCharacterEntered()
    	sw.Start()
    End Sub
    Private Sub txt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt.TextChanged
    	If txt.length = 0 Then FirstCharacterEntered()
    	If txt.Length = BarCodeSerialLength Or New RegularExpressions.Regex("your pattern").IsMatch(txt.Text) Then
    		sw.Stop()
    		If sw.ElapsedMilliseconds < TimeAHumanWouldTakeToType Then
    			'Input is from the BarCode Scanner
    		End If    
    	End If
    End Sub
