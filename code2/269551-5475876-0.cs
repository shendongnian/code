    Public Function CalculateRequireRsaKeyLength(ByRef ByteArrayToEncrypt As Byte()) As Int32
        Try
            Dim TotalBytesEncryptable As Int32
            
            'TotalBytesEncryptable = ((KeyLength - 384) / 8) + 7
            TotalBytesEncryptable = ByteArrayToEncrypt.Length - 7
            TotalBytesEncryptable = TotalBytesEncryptable * 8
            TotalBytesEncryptable = TotalBytesEncryptable + 384
            If TotalBytesEncryptable <= 384 Then
                Return 384
            End If
            If TotalBytesEncryptable >= 16384 Then
                'means error
                Return 0
            End If
            Return TotalBytesEncryptable
        Catch ex As Exception
            'System.IO.File.WriteAllText("e:\qqwwee.txt", ex.ToString)
            Return 0
        End Try
    End Function
