     Imports System.Windows.Forms
    Imports System.ComponentModel
    
    Public Class FormEx
        Inherits Form
    
        Private Declare Function MoveWindow Lib "User32.dll" (ByVal hWnd As IntPtr, ByVal x As Integer, ByVal y As Integer, ByVal w As Integer, ByVal h As Integer, ByVal Repaint As Boolean) As Boolean
    
        Private Const DEFAULTSIZE_X = 1024
        Private Const DEFAULTSIZE_Y = 768
    
        Protected Overrides Sub OnHandleCreated(e As System.EventArgs)
            MyBase.OnHandleCreated(e)
    
            If mSizeRuntime = System.Drawing.Size.Empty Then
                SizeRuntime = New System.Drawing.Size(DEFAULTSIZE_X, DEFAULTSIZE_Y)
            End If
    
            If mSizeDesign = System.Drawing.Size.Empty Then
                SizeDesign = New System.Drawing.Size(DEFAULTSIZE_X, DEFAULTSIZE_Y)
            End If
        End Sub
    
        <Browsable(False)> _
        Public Shadows Property Size As System.Drawing.Size
    
        Private mSizeDesign As System.Drawing.Size = System.Drawing.Size.Empty
        <Category("Layout"), _
        Description("Sets the size of the form at design time."), _
        RefreshProperties(RefreshProperties.All)> _
        Public Property SizeDesign As System.Drawing.Size
            Get
                Return mSizeDesign
            End Get
            Set(value As System.Drawing.Size)
                mSizeDesign = value
                If Me.DesignMode Then
                    MoveWindow(Me.Handle, Me.Left, Me.Top, value.Width, value.Height, True)
                End If
            End Set
        End Property
    
        Private mSizeRuntime As System.Drawing.Size = System.Drawing.Size.Empty
        <Category("Layout"), _
        Description("Sets the size of the form at runtime."), _
        DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)> _
        Public Property SizeRuntime As System.Drawing.Size
            Get
                Return mSizeRuntime
            End Get
            Set(value As System.Drawing.Size)
                mSizeRuntime = value
                If Not Me.DesignMode Then
                    MyBase.Size = value
                End If
            End Set
        End Property
    
    End Class
