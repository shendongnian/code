    Protected Sub calArrival_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles calArrival.SelectionChanged
        SetFormDepartureEntry()
    
        lblArrivalDate.Text = calArrival.SelectedDate.ToLongDateString
        calDeparture.SelectedDate = calArrival.SelectedDate
        calDeparture.VisibleDate = calArrival.SelectedDate
        dtSelectedArrival = "1/1/2000"
    
        'Determine if we need to see 2 months to view all possible departure dates.
        If (DatePart(DateInterval.Month, calDeparture.SelectedDate) <> _
            DatePart(DateInterval.Month, DateAdd(DateInterval.Day, 14, calDeparture.SelectedDate))) Then
            calDeparture2.Visible = True
            calDeparture2.SelectedDate = Nothing
            calDeparture2.VisibleDate = DateAdd(DateInterval.Month, 1, calDeparture.SelectedDate)
        Else
            calDeparture2.Visible = False
        End If
        End Sub
