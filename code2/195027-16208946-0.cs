    Imports System.Runtime.CompilerServices
    Imports System.IO
    Imports System.IO.Compression
    
    Public Module Compressor
    
        <Extension()> _
        Function CompressASCII(str As String) As Byte()
    
            Dim bytes As Byte() = Encoding.ASCII.GetBytes(str)
    
            Using ms As New MemoryStream
    
                Using gzStream As New GZipStream(ms, CompressionMode.Compress)
    
                    gzStream.Write(bytes, 0, bytes.Length)
    
                End Using
    
                Return ms.ToArray
    
            End Using
    
        End Function
    
        <Extension()> _
        Function DecompressASCII(compressedString As Byte()) As String
    
            Using ms As New MemoryStream(compressedString)
    
                Using gzStream As New GZipStream(ms, CompressionMode.Decompress)
    
                    Using sr As New StreamReader(gzStream, Encoding.ASCII)
    
                        Return sr.ReadToEnd
    
                    End Using
    
                End Using
    
            End Using
    
        End Function
    
        Sub TestCompression()
    
            Dim input As String = "fh3o047gh"
    
            Dim compressed As Byte() = input.CompressASCII()
    
            Dim decompressed As String = compressed.DecompressASCII()
    
            If input <> decompressed Then
                Throw New ApplicationException("failure!")
            End If
    
        End Sub
    
    End Module
