    Imports System.Collections.ObjectModel
    Imports System.ComponentModel
    
    Public Class MyType
        Public Sub New()
            ' initialize the collection
            _MyTypeItemList = From a In MyTypeItemList Select a Order By a.MyProperty2
        End Sub
    
        Private _MyTypeItemList As New ObservableCollection(Of MyTypeItem)
    
        Public ReadOnly Property MyTypeItemList() As ObservableCollection(Of MyTypeItem)
            Get
                MyTypeItemList = _MyTypeItemList
            End Get
        End Property
    End Class
    
    Public Class MyTypeItem
        Implements INotifyPropertyChanged
    
        Public Sub New(ByVal MyProperty1Pass As Long, ByVal MyProperty2Pass As Date)
            _MyProperty1 = MyProperty1Pass
            _MyProperty2 = MyProperty2Pass
        End Sub
    
        Private _MyProperty1 As Long = Nothing
        Private _MyProperty2 As Date = Nothing
    
        Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
    
        Public Property MyProperty1() As Long
            Get
                MyProperty1 = Me._MyProperty1
            End Get
    
            Set(ByVal value As Long)
                If Not Object.Equals(Me._MyProperty1, value) Then
                    Me._MyProperty1 = value
                    Me.OnPropertyChanged("MyProperty1")
                End If
            End Set
        End Property
    
        Public Property MyProperty2() As Date
            Get
                Return Me._MyProperty2
            End Get
    
            Set(ByVal value As Date)
                If Not Object.Equals(Me._MyProperty2, value) Then
                    Me._MyProperty2 = value
                    Me.OnPropertyChanged("MyProperty2")
                End If
            End Set
        End Property
    
        Protected Overridable Sub OnPropertyChanged(ByVal propertyName As String)
            Dim handler As PropertyChangedEventHandler = Me.PropertyChangedEvent
            If handler IsNot Nothing Then
                RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
            End If
        End Sub
    End Class
