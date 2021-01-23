    Imports System.ComponentModel
    Imports System.Reflection
    Imports System.Runtime.CompilerServices
    Imports System.Windows.Forms
    Public Module Extensions
    <Extension()>
    Public Sub DisableSorting(datagrid As DataGridView)
        For index = 0 To datagrid.Columns.Count - 1
            datagrid.Columns(index).SortMode = DataGridViewColumnSortMode.NotSortable
        Next
    End Sub
    <Extension()>   
    Public Sub SetDoubleBuffered (dgv As DataGridView, doubleBuffered As Boolean)  
        Try
            Dim dgvType As Type = dgv.GetType()
            Dim pi As PropertyInfo = dgvType.GetProperty("DoubleBuffered", BindingFlags.Instance Or BindingFlags.NonPublic)
            pi.SetValue(dgv, doubleBuffered, Nothing)
        Catch ex As Exception
            'Do Nothing, just eat the exception
        End Try
    End Sub
    <Extension()>
    Public Sub ClearAllSelections(myToolStrip As ToolStrip)
        Dim type = myToolStrip.GetType()
        Dim method As MethodInfo = type.GetMethod("ClearAllSelections", BindingFlags.NonPublic Or BindingFlags.Instance)
        method.Invoke(myToolStrip, Nothing)
    End Sub
    <Extension()>   
    Public Sub SetDoubleBuffered (checkedListBox As CheckedListBox, doubleBuffered As Boolean)  
        Try
            Dim dgvType As Type = checkedListBox.GetType()
            Dim pi As PropertyInfo = dgvType.GetProperty("DoubleBuffered", BindingFlags.Instance Or BindingFlags.NonPublic)
            pi.SetValue(checkedListBox, doubleBuffered, Nothing)
        Catch ex As Exception
            'Do Nothing, just eat the exception
        End Try
    End Sub 
    <Extension()>
    Public Function IsDesignerHosted(originalControl As Control) As Boolean
        If LicenseManager.UsageMode = LicenseUsageMode.Designtime Then
            Return True
        Else
            Dim ctrl = originalControl
            While ctrl IsNot Nothing
                If ctrl.Site IsNot Nothing AndAlso ctrl.Site.DesignMode Then
                    Return True
                End If
                ctrl = ctrl.Parent
            End While
            Return False
        End If
    End Function
    End Module
