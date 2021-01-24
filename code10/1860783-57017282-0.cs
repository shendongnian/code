    Imports System.IO
    Imports System.Runtime.Serialization.Formatters.Binary
    Imports System.Web.UI
    Public Module UserStates
    Public Property CurrSessionVariableIndex As Integer
        Get
            Dim I As Integer
            If LDB.CustomData.TryGetValue("CurrSessionIndex", I) Then
                Return I
            Else
                LDB.CustomData("CurrSessionIndex") = 1
                Return I
            End If
        End Get
        Set(value As Integer)
            LDB.CustomData("CurrSessionIndex") = value
        End Set
    End Property
    Public Function NewSessionVariableIndex() As Integer
        CurrSessionVariableIndex += 1
        Return CurrSessionVariableIndex
    End Function
    Public PreferMemoryMapFiles As Boolean = True
    Public ViewStatusBags As New Dictionary(Of Integer, Dictionary(Of String, Object))(300)
    Public ViewStatusTimes As New Dictionary(Of Integer, DateTime)(300)
    Public Sub SetViewVarRAM(ViewStateID As Integer, key As String, Obj As Object)
        Dim Bag As Dictionary(Of String, Object) = Nothing
        If ViewStatusBags.TryGetValue(ViewStateID, Bag) Then
            Try
                Bag(key) = Obj
            Catch ex As Exception
                Log($"Added new ViewBag.Var {ViewStateID}.{key}")
                Bag.Add(key, Obj)
            End Try
            ViewStatusTimes(ViewStateID) = Now
        Else
            Log($"Added new ViewBag {ViewStateID}")
            Bag = New Dictionary(Of String, Object)
            ViewStatusBags.Add(ViewStateID, Bag)
            ViewStatusTimes.Add(ViewStateID, Now)
            Bag.Add(key, Obj)
        End If
    End Sub
    Public Function GetViewVarRAM(ViewStateID As Integer, key As String) As Object
        Dim Bag As Dictionary(Of String, Object) = Nothing
        If ViewStatusBags.TryGetValue(ViewStateID, Bag) Then
            ViewStatusTimes(ViewStateID) = Now
            Try
                Return Bag(key)
            Catch ex As Exception
                Log($"Added new ViewBag.Var {ViewStateID}.{key}")
                Bag.Add(key, Nothing)
                Return Bag(key)
            End Try
        Else
            Log($"Added new ViewBag {ViewStateID}")
            Bag = New Dictionary(Of String, Object)
            ViewStatusBags.Add(ViewStateID, Bag)
            ViewStatusTimes.Add(ViewStateID, Now)
            Bag.Add(key, Nothing)
            Return Bag(key)
        End If
    End Function
    Public Function GetViewMMF(ViewStateID As Integer) As Dictionary(Of String, Object)
        Dim FS As FileStream = Nothing
        Dim BF As New BinaryFormatter
        GetFileStream(ViewStateID, FS)
        Dim Bag As Dictionary(Of String, Object)
        Try
            Bag = BF.Deserialize(FS)
        Catch ex As Exception
            If Not ex.Message.StartsWith("Attempting to deserialize an empty stream") Then
                LogError(ex, $"@MMF.Get : cannot Deserialize FS {ViewStateID}")
            End If
            FS.Flush()
            Bag = New Dictionary(Of String, Object)
            SetViewMMF(ViewStateID, Bag)
        End Try
        Try
            FS.Flush()
        Catch ex As Exception
        End Try
        Return Bag
    End Function
    Public Sub SetViewMMF(ViewStateID As Integer, Bag As Dictionary(Of String, Object))
        Dim FS As FileStream = Nothing
        Dim BF As New BinaryFormatter
        GetFileStream(ViewStateID, FS)
        Try
            BF.Serialize(FS, Bag)
        Catch ex As Exception
            LogError(ex, $"@MMF.Set : cannot Serialize FS {ViewStateID}")
            FS.Flush()
        End Try
        Try
            FS.Flush()
        Catch ex As Exception
        End Try
    End Sub
    Public MMFStreams As New Dictionary(Of Integer, FileStream)(100)
    Public MMFStreamsTimes As New Dictionary(Of Integer, Date)(100)
    Public FilePathMMFs As String
    Private Sub GetFileStream(ByRef ViewStateID As Integer, ByRef FS As FileStream)
        If MMFStreams.TryGetValue(ViewStateID, FS) Then
            Try
                FS.Seek(0, SeekOrigin.Begin)
            Catch ex As Exception
                LogError(ex, $"@MMF.Set : cannot restart FS {ViewStateID}")
                FS = New FileStream(FilePathMMFs & ViewStateID.ToString & "-" & Rand.Next(100, 1000).ToString, FileMode.OpenOrCreate)
                FS.Seek(0, SeekOrigin.Begin)
                MMFStreams(ViewStateID) = FS
            End Try
            MMFStreamsTimes(ViewStateID) = Now
        Else
            Try
                FS = New FileStream(FilePathMMFs & ViewStateID.ToString, FileMode.OpenOrCreate)
                FS.Seek(0, SeekOrigin.Begin)
                MMFStreams.Add(ViewStateID, FS)
            Catch ex As Exception
                LogError(ex, $"@MMF.Set : cannot OpenOrCreate new FS {ViewStateID}")
                FS = New FileStream(FilePathMMFs & ViewStateID.ToString & "-" & Rand.Next(100, 1000).ToString, FileMode.OpenOrCreate)
                FS.Seek(0, SeekOrigin.Begin)
                MMFStreams.Add(ViewStateID, FS)
            End Try
            MMFStreamsTimes(ViewStateID) = Now
        End If
    End Sub
    Public Sub SetViewVarMMF(ViewStateID As Integer, key As String, Obj As Object)
        Dim FS As FileStream = Nothing
        Dim BF As New BinaryFormatter
        GetFileStream(ViewStateID, FS)
        Dim Bag As Dictionary(Of String, Object)
        Try
            Bag = BF.Deserialize(FS)
        Catch ex As Exception
            'LogError(ex, $"@MMF.SetViewVarMMF : cannot Deserialize FS {ViewStateID}. saved new bag")
            Bag = New Dictionary(Of String, Object)
        End Try
        FS.Seek(0, SeekOrigin.Begin)
        If Bag.ContainsKey(key) Then
            Bag(key) = Obj
        Else
            Bag.Add(key, Obj)
        End If
        Try
            BF.Serialize(FS, Bag)
        Catch ex As Exception
            LogError(ex, $"@MMF.SetViewVarMMF : cannot Serialize FS {ViewStateID}")
            FS.Flush()
        End Try
        Try
            FS.Flush()
        Catch ex As Exception
        End Try
    End Sub
    Public Function GetViewVarMMF(ViewStateID As Integer, key As String) As Object
        Dim Bag = GetViewMMF(ViewStateID)
        Dim Obj As Object = Nothing
        If Bag.TryGetValue(key, Obj) Then
            Return Obj
        Else
            Return Nothing
        End If
        Bag = Nothing
    End Function
    Public AllUserContainer As New Dictionary(Of Integer, UserContainer)(50)
    Public Sub SetUserContainer(Usr As Integer, Con As UserContainer)
        Con.UserID = Usr
        If AllUserContainer.ContainsKey(Usr) Then
            AllUserContainer(Usr) = Con
            Con.Time = Now
        Else
            Log($"Added new user {Usr}")
            AllUserContainer.Add(Usr, Con)
            Con.Time = Now
        End If
    End Sub
    Public Function GetUserContainer(Usr As Integer) As UserContainer
        Dim Con As UserContainer = Nothing
        If AllUserContainer.TryGetValue(Usr, Con) Then
            Con.Time = Now
            Return Con
        Else
            Log($"Added new user {Usr}")
            Con = New UserContainer(Usr)
            AllUserContainer.Add(Usr, Con)
            Con.Time = Now
            Return Con
        End If
    End Function
    '___________________________________________________'
    Public Sub SetViewVar(ViewStateID As Integer, key As String, Obj As Object)
        If PreferMemoryMapFiles Then
            SetViewVarMMF(ViewStateID, key, Obj)
        Else
            SetViewVarRAM(ViewStateID, key, Obj)
        End If
    End Sub
    Public Function GetViewVar(ViewStateID As Integer, key As String) As Object
        If PreferMemoryMapFiles Then
            Return GetViewVarMMF(ViewStateID, key)
        Else
            Return GetViewVarRAM(ViewStateID, key)
        End If
    End Function
    Public Sub RemoveMMF(ViewStateID As Integer)
        Dim FS As FileStream = Nothing
        If MMFStreams.TryGetValue(ViewStateID, FS) Then
            Try
                FS.Close()
            Catch ex As Exception
            End Try
        End If
    End Sub
    Public Sub RemoveUserContainer(Usr As Integer)
        If AllUserContainer.ContainsKey(Usr) Then
            AllUserContainer(Usr).Dispose()
            AllUserContainer.Remove(Usr)
            Log($"Removed user {Usr}")
        End If
    End Sub
    Public Sub DeleteUnusedMMFs()
        Dim Files = Directory.GetFiles(FilePathMMFs)
        Dim nowTime As Date = Now
        Dim nOfFiles = 0I
        For Each FilePath In Files
            Dim FileID = Path.GetFileName(FilePath)
            Dim Time As Date = Date.MinValue
            If UserStates.MMFStreamsTimes.TryGetValue(FileID, Time) Then
                If Time.AddMinutes(5) < nowTime Then
                    Try
                        UserStates.MMFStreams(FileID).Close()
                    Catch ex As Exception
                    End Try
                    Try
                        File.Delete(FilePath)
                        nOfFiles += 1
                    Catch ex As Exception
                    End Try
                End If
            Else
                Try
                    File.Delete(FilePath)
                    nOfFiles += 1
                Catch ex As Exception
                End Try
            End If
        Next
        Log($"@ViewStates.DeleteUnusedMMFs : {nOfFiles} deleted")
    End Sub
    '___________________________________________________'
    Public Sub ClearUnusedViewStates()
        Dim BeforeRAM = (My.Application.Info.WorkingSet / 1024) / 1024
        Dim CurrTime = Now
        Dim ToRemove As New List(Of Integer)
        Dim ViewEntries As Integer
        Dim UsrEntries As Integer
        If ViewStatusBags.Count = 0 Then
            GoTo RemoveusrsLbl
        End If
        For i = ViewStatusBags.Count - 1 To 0 Step -1
            Dim Time = ViewStatusTimes.ElementAt(i).Value
            If Time.AddMinutes(5) < CurrTime Then
                ToRemove.Add(ViewStatusBags.ElementAt(i).Key)
            End If
        Next
        ViewEntries = ToRemove.Count
        For Each i In ToRemove
            ViewStatusBags.Remove(i)
        Next
     RemoveusrsLbl:
        If AllUserContainer.Count = 0 Then
            GoTo Final
        End If
        For i = AllUserContainer.Count - 1 To 0 Step -1
            If AllUserContainer(i).Time.AddMinutes(15) < CurrTime Then
                AllUserContainer.Remove(AllUserContainer(i).UserID)
                UsrEntries += 1
            End If
        Next
    Final:
        GC.Collect()
        Dim AfterRAM = (My.Application.Info.WorkingSet / 1024) / 1024
        Log($"@ViewStates : {ViewEntries} Unused ViewStates Cleared. {UsrEntries} inactive users cleared. {AfterRAM - BeforeRAM} MB Cleared. ")
    End Sub
    End Module
