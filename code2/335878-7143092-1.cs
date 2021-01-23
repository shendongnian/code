    Imports System.Runtime.CompilerServices
    Public Module Extensions
        <Extension()>
        Public Function GetAnyControlAt(Panel As TableLayoutPanel, Column As Integer, Row As Integer) As Control
            For Each PanelControl As Control In Panel.Controls
                With Panel.GetCellPosition(PanelControl)
                    If Column = .Column AndAlso Row = .Row Then Return PanelControl
                End With
            Next
            Return Nothing
        End Function
    End Module
