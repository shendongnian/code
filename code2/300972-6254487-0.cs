    Imports System
    Imports System.Collections.Generic
    Imports System.IO.Compression
    Imports System.IO
    Imports System.Collections
    
    Namespace Utilities
    
        Class Compression
    
            Public Shared Function Compress(ByVal data As Byte()) As Byte()
                Dim ms As New MemoryStream()
                Dim ds As New DeflateStream(ms, CompressionMode.Compress)
                ds.Write(data, 0, data.Length)
                ds.Flush()
                ds.Close()
                Return ms.ToArray()
            End Function
    
    
            Public Shared Function Decompress(ByVal data() As Byte) As Byte()
                Try
    
                    'Copy the data (compressed) into ms.
                    Using ms As New MemoryStream(data)
                        Using zipStream As Stream = New DeflateStream(ms, CompressionMode.Decompress, True)
                            'Decompressing using data stored in ms.
                            'zipStream = New DeflateStream(ms, CompressionMode.Decompress, True)
                            'Used to store the decompressed data.
                            Dim dc_data As Byte()
                            'The decompressed data is stored in zipStream; 
                            ' extract them out into a byte array.
                            dc_data = RetrieveBytesFromStream(zipStream, data.Length)
                            Return dc_data
                        End Using
                    End Using
                Catch ex As Exception
                    MsgBox(ex.ToString)
                    Return Nothing
                End Try
            End Function
    
            Public Shared Function RetrieveBytesFromStream( _
           ByVal stream As Stream, ByVal bytesblock As Integer) As Byte()
    
                'Retrieve the bytes from a stream object.
                Dim data() As Byte
                Dim totalCount As Integer = 0
                Try
                    While True
                        'Progressively increase the size of the data byte array.
                        ReDim Preserve data(totalCount + bytesblock)
                        Dim bytesRead As Integer = stream.Read(data, totalCount, bytesblock)
                        If bytesRead = 0 Then
                            Exit While
                        End If
                        totalCount += bytesRead
                    End While
                    'Make sure the byte array contains exactly the number
                    'of bytes extracted.
                    ReDim Preserve data(totalCount - 1)
                    Return data
                Catch ex As Exception
                    MsgBox(ex.ToString)
                    Return Nothing
                End Try
    
            End Function
            
        End Class
    End Namespace
