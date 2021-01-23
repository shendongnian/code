MustInherit Class PointRef
    Public MustOverride Property thePoint() As Point
    Public Property X() As Integer
        Get
            Return thePoint.X
        End Get
        Set(ByVal value As Integer)
            Dim mypoint As Point = thePoint
            mypoint.X = X
            thePoint = mypoint
        End Set
    End Property
    Public Property Y() As Integer
        Get
            Return thePoint.X
        End Get
        Set(ByVal value As Integer)
            Dim mypoint As Point = thePoint
            mypoint.Y = Y
            thePoint = mypoint
        End Set
    End Property
    Public Shared Widening Operator CType(ByVal val As Point) As PointRef
        Return New onePoint(val)
    End Operator
    Public Shared Widening Operator CType(ByVal val As PointRef) As Point
        Return val.thePoint
    End Operator
    Private Class onePoint
        Inherits PointRef
        Dim myPoint As Point
        Sub New(ByVal pt As Point)
            myPoint = pt
        End Sub
        Public Overrides Property thePoint() As System.Drawing.Point
            Get
                Return myPoint
            End Get
            Set(ByVal value As System.Drawing.Point)
                myPoint = value
            End Set
        End Property
    End Class
End Class
Class pointHolder
    Dim myPoints As New Dictionary(Of Integer, Point)
    Private Class IndexedPointRef
        Inherits PointRef
        Dim ref As pointHolder
        Dim index As Integer
        Sub New(ByVal ref As pointHolder, ByVal index As Integer)
            Me.ref = ref
            Me.index = index
        End Sub
        Public Overrides Property thePoint() As System.Drawing.Point
            Get
                Dim mypoint As New Point(0, 0)
                ref.myPoints.TryGetValue(index, mypoint)
                Return mypoint
            End Get
            Set(ByVal value As System.Drawing.Point)
                ref.myPoints(index) = value
            End Set
        End Property
    End Class
    Default Public Property item(ByVal index As Integer) As PointRef
        Get
            Return New IndexedPointRef(Me, index)
        End Get
        Set(ByVal value As PointRef)
            myPoints(index) = value.thePoint
        End Set
    End Property
    Shared Sub test()
        Dim theH1, theH2 As New pointHolder
        theH1(5).X = 9
        theH1(9).Y = 20
        theH2(12).X = theH1(9).Y
        theH1(20) = theH2(12)
        theH2(12).Y = 6
        Dim h5, h9, h12, h20 As Point
        h5 = theH1(5)
        h9 = theH1(9)
        h12 = theH2(12)
        h20 = theH1(20)
    End Sub
End Class
