    Private Sub MyEventHandler()
        _ShipmentCollectionView.Filter = New Predicate(Of Object)(AddressOf FilterOut)
    End Sub
    Private Function FilterOut(ByVal item As Object) As Boolean
            Dim MyShipment As Shipment = CType(item, Shipment)
            If _FilterDelivered And MyShipment.TransitStatus = eTransitStatus.Delivered Then
                Return False
            End If
            If _FilterOverdue And MyShipment.TransitStatus = eTransitStatus.InTransit AndAlso MyShipment.ExpectedDate < Today Then
                Return False
            End If
            If _FilterUnshipped And MyShipment.TransitStatus = eTransitStatus.Unshipped Then
                Return False
            End If
            If SearchString Is Nothing Or SearchString = "" Then
                Return True
            Else
    
                Return MyShipment.Contains(SearchString)
            End If
        End Function
