     <Runtime.CompilerServices.Extension()>
        Public Function Paginate(Of T As {Class})(source As T, skip As Integer, take As Integer) As T
        If source IsNot Nothing AndAlso TypeOf source Is IEnumerable Then
    
            Dim chunk = (From c In DirectCast(source, IEnumerable)).Skip(skip).Take(take).ToList
            If chunk.Count = 0 Then Return Nothing
    
            Return AutoMapper.Mapper.Map(chunk, GetType(T), GetType(T))
        End If
        Return source
    End Function
