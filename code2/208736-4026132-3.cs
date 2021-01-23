    Imports System
    Imports System.ComponentModel
    Imports System.ComponentModel.Design.Serialization
    Imports System.Windows
    Imports System.Windows.Controls
    Imports System.Windows.Forms.Integration
    Imports System.Windows.Forms.Design
    
    <Designer(GetType(ControlDesigner))> _
    Class SpellBox
        Inherits ElementHost
    
        Public Sub New()
            box = New TextBox()
            MyBase.Child = box
            AddHandler box.TextChanged, AddressOf box_TextChanged
            box.SpellCheck.IsEnabled = True
            box.VerticalScrollBarVisibility = ScrollBarVisibility.Auto
            Me.Size = New System.Drawing.Size(100, 20)
        End Sub
    
        Private Sub box_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
            OnTextChanged(EventArgs.Empty)
        End Sub
    
        Public Overrides Property Text() As String
            Get
                Return box.Text
            End Get
            Set(ByVal value As String)
                box.Text = value
            End Set
        End Property
    
        <DefaultValue(False)> _
        Public Property MultiLine() As Boolean
            Get
                Return box.AcceptsReturn
            End Get
            Set(ByVal value As Boolean)
                box.AcceptsReturn = value
            End Set
        End Property
    
        <DefaultValue(False)> _
        Public Property WordWrap() As Boolean
            Get
                Return box.TextWrapping <> TextWrapping.NoWrap
            End Get
            Set(ByVal value As Boolean)
                If value Then
                    box.TextWrapping = TextWrapping.Wrap
                Else
                    box.TextWrapping = TextWrapping.NoWrap
                End If
            End Set
        End Property
    
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
        Public Shadows Property Child() As System.Windows.UIElement
            Get
                Return MyBase.Child
            End Get
            Set(ByVal value As System.Windows.UIElement)
                '' Do nothing to solve a problem with the serializer !!
            End Set
        End Property
        Private box As TextBox
    End Class
