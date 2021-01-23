    '' VS Macro Module: IkiVsProductivity2008
    ''
    
    Imports System
    Imports EnvDTE
    Imports EnvDTE80
    Imports EnvDTE90
    Imports System.Diagnostics
    
    Public Module IkiVsProductivity2008
    
        ' Adjust words in current selection
        '
        Sub IvpLineEmUp()
            Dim selection As EnvDTE.TextSelection
            Dim editPoint As EnvDTE.EditPoint
            Dim rows As Long
            Dim howFarOut As Long = 1
            Dim anyMoved As Boolean = False
    
            Try
                DTE.UndoContext.Open("IvpLineEmUp")
    
                selection = ActiveDocument.Selection
                editPoint = selection.TopPoint.CreateEditPoint
                rows = selection.BottomPoint.Line - selection.TopPoint.Line + 1
    
                ' Iterate to find the first row that isn't already aligned.
                Do While Not anyMoved
                    Dim AnyRowValid = False
    
                    ' The current character and display columns of each element in the
                    ' current word column.
                    Dim curCharPos(rows) As Long
                    Dim curDispPos(rows) As Long
                    ' The lowest possible columns at which each element could begin if
                    ' whitespace was compressed.
                    Dim minCharPos(rows) As Long
                    Dim minDispPos(rows) As Long
    
                    ' Iterate over each selected row.
                    Dim arrIdx As Long = 0
                    Dim maxMinPosIdx As Long = -1
    
                    editPoint.MoveToLineAndOffset(selection.TopPoint.Line, 1)
                    For arrIdx = 0 To rows - 1
                        Dim originalLine As Long
    
                        originalLine = editPoint.Line
                        editPoint.StartOfLine()
                        If howFarOut > 1 Then
                            Dim wordCount As Long
    
                            For wordCount = 1 To howFarOut
                                MoveWordRight(editPoint)
                            Next
                        Else
                            SkipSpaceRight(editPoint)
                        End If
    
                        ' If we ran off the end of the line, ignore this one.
                        If editPoint.Line > originalLine Then
                            curCharPos(arrIdx) = -1
                            curDispPos(arrIdx) = -1
                            minCharPos(arrIdx) = -1
                            minDispPos(arrIdx) = -1
                        Else
                            ' Determine the current display column of the EditPoint.
                            curCharPos(arrIdx) = editPoint.LineCharOffset
                            curDispPos(arrIdx) = editPoint.DisplayColumn
    
                            ' Determine the minimum column that this element can start
                            ' at (there maybe extra whitespace to the left that can be
                            ' eliminated).
                            If howFarOut > 1 Then
                                Do While IsWhitespace(editPoint.GetText(-2))
                                    editPoint.CharLeft()
                                Loop
                            End If
                            minCharPos(arrIdx) = editPoint.LineCharOffset
                            minDispPos(arrIdx) = editPoint.DisplayColumn
                            ' Keep track of the maximum minpos.
                            If maxMinPosIdx = -1 OrElse minDispPos(maxMinPosIdx) < minDispPos(arrIdx) Then
                                maxMinPosIdx = arrIdx
                            End If
                        End If
                        editPoint.LineDown()
                    Next
    
                    ' Now look at the CurPos and MinPos arrays to determine the
                    ' leftmost column at which all the elements can be aligned.
                    anyMoved = False
    
                    For arrIdx = 0 To rows - 1
                        If curDispPos(arrIdx) <> -1 Then
                            AnyRowValid = True
                            If curDispPos(arrIdx) <> minDispPos(maxMinPosIdx) Then
                                ' This element is not correctly aligned; move it to the
                                ' correct column.
                                anyMoved = True
                                editPoint.MoveToLineAndOffset(arrIdx + selection.TopPoint.Line, curCharPos(arrIdx))
                                editPoint.DeleteWhitespace(vsWhitespaceOptions.vsWhitespaceOptionsHorizontal)
                                IvpLineEmUp_PadToColumn(editPoint, minDispPos(maxMinPosIdx))
                            End If
                        End If
                    Next
    
                    ' If we ran out of elements to align, terminate the loop.
                    If Not AnyRowValid Then
                        anyMoved = True
                    End If
                    howFarOut = howFarOut + 1
                Loop
                IvpFixLineEnds()
    
            Finally
                DTE.UndoContext.Close()
            End Try
        End Sub
    
        ' internal method used by LineEmUp macro
        '
        Sub IvpLineEmUp_PadToColumn(ByRef editPoint As EnvDTE.EditPoint, ByVal column As Integer)
            If editPoint.DisplayColumn > column Then Exit Sub
            Dim spaces As String = Space(column - editPoint.DisplayColumn)
            editPoint.Insert(spaces)
        End Sub
    
        '' FixLineEnds removes whitespace from the ends of all lines in the selection.
        '' Then for any line in the selection that ends with a semicolon, eliminates
        '' any whitespace between the semicolon and the previous character.
        ''
        Sub IvpFixLineEnds()
            Dim selection As EnvDTE.TextSelection
            Dim editPoint As EnvDTE.EditPoint
    
            selection = ActiveDocument.Selection
            editPoint = selection.TopPoint.CreateEditPoint
            Do While editPoint.Line < selection.BottomPoint.Line
                editPoint.EndOfLine()
                editPoint.DeleteWhitespace(vsWhitespaceOptions.vsWhitespaceOptionsHorizontal)
                If editPoint.GetText(-1) = ";" Then
                    editPoint.CharLeft()
                    editPoint.DeleteWhitespace(vsWhitespaceOptions.vsWhitespaceOptionsHorizontal)
                End If
                editPoint.LineDown()
            Loop
        End Sub
    
    End Module
