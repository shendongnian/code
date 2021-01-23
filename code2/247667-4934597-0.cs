    Public Class SomeClass(Of T As {WebControl, ITextControl})
        Private _item As T
        Public Property Item() As T
            Get
                Return Me._item
            End Get
            Set(ByVal value As T)
                Me.ParseValue(value)
                Me._item = value
            End Set
        End Property
        Public Sub ParseValue(ByVal value As T)
            ''//do something with value here if you want
        End Sub
        Public Sub New(ByVal item As T)
            Me._item = item
        End Sub
    End Class
