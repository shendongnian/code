        Public Shared Function GetIdle() As UInteger
            Dim lii As New LASTINPUTINFO()
            lii.cbSize = Convert.ToUInt32((Marshal.SizeOf(lii)))
            GetLastInputInfo(lii)
    
            Dim totalTicks As Long = 0
    
            If Environment.TickCount > 0 Then
                totalTicks = Convert.ToUInt64(Environment.TickCount)
            Else
                totalTicks = Convert.ToUInt64(Environment.TickCount * -1)
            End If
    
            Return Math.Abs(totalTicks - lii.dwTime)
    
        End Function
