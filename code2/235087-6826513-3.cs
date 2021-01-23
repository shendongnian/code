    Namespace Extensions
        Public Module ModDateTimeExtensions
    
            <System.Runtime.CompilerServices.Extension()> _
            Public Function GetUserTimeFromUTC(ByVal dtUtcTime As DateTime, ByVal id As String) As DateTime
                Return TimeZoneInfo.ConvertTimeFromUtc(dtUtcTime, TimeZoneInfo.FindSystemTimeZoneById(id))
            End Function
    
            <System.Runtime.CompilerServices.Extension()> _
            Public Function SetUserTimeToUTC(ByVal dtUserTime As DateTime, ByVal id As String) As DateTime
                Return TimeZoneInfo.ConvertTime(dtUserTime, TimeZoneInfo.FindSystemTimeZoneById(id), TimeZoneInfo.Utc)
            End Function
    
        End Module
    End Namespace
