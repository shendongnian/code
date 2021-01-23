    Imports System.ComponentModel
    
    Public MustInherit Class ViewModelBase
        Implements INotifyPropertyChanged
    
        Public Event PropertyChanged As PropertyChangedEventHandler _
            Implements INotifyPropertyChanged.PropertyChanged
    
        Protected Sub OnPropertyChanged(ByVal info As String)
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(info))
        End Sub
    
    End Class
