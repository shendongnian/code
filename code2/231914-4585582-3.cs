    Class MainWindow 
    
        Private Sub CreateButtons(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
            Dim ImageButtonCVS As CollectionViewSource = Me.FindResource("ImageButtonsCVS")
            ImageButtonCVS.Source = New ImageButtonCollection
        End Sub
    End Class
