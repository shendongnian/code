    Public Function GetSubGroups(ByVal groupname As String) As List(Of String)
        Dim result As New List(Of String)()
        GetSubGroups(groupname, result)
        Return result
    End Function
    Public Sub GetSubGroups(ByVal Group As String, ByRef l As List(Of String))
        Dim grp = GetGroup(Group)
        'sometimes group will be null if its a system built in group like "authenticated users"'
        If grp Is Nothing Then
            Exit Sub
        End If
        Dim sGroups = GetGroupMembership(Group, False).Where(Function(c) TypeOf c Is GroupPrincipal)
        For Each g In sGroups
            Dim n As String = FormatPrincipalName(g.Name)
            If Not l.Contains(n) Then
                l.Add(n)
                GetSubGroups(g.Name, l)
            End If
        Next
    End Sub
    Public Function GetGroupMembership(ByVal GroupName As String, Optional ByVal Recursive As Boolean = True) As PrincipalGenericCollection(Of Principal)
        Dim group As GroupPrincipal = GetGroup(GroupName)
        If group Is Nothing Then
            Return Nothing
        End If
        Dim prinCol As New PrincipalGenericCollection(Of Principal)(group.GetMembers(Recursive))
        prinCol.SortByName()
        Return prinCol
    End Function
    Public Class PrincipalGenericCollection(Of T As Principal)
        Inherits List(Of T)
    
        Public Sub New()
            MyBase.New()
        End Sub
    
        Public Sub New(ByVal collection As PrincipalCollection)
            For Each p As Principal In collection
                Me.Add(p)
            Next
        End Sub
    
        Public Sub New(ByVal collection As IEnumerable(Of T))
            MyBase.New(collection)
        End Sub
    
        Public Sub SortByName()
            Sort(New PrincipalSorter(Of T))
        End Sub
    End Class
