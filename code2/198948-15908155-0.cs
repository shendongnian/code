                Using document As WordprocessingDocument = WordprocessingDocument.Open(cls_sNewFilename, True)
                    Dim mainPart As MainDocumentPart = document.MainDocumentPart
                    Dim body As Body = mainPart.Document.Body
                    'if custom xml content exists, delete it first
                    mainPart.DeleteParts(Of CustomXmlPart)(mainPart.CustomXmlParts)
                    For Each sdt As SdtElement In body.Descendants(Of SdtElement)().ToList()
                        Dim [alias] As SdtAlias = sdt.Descendants(Of SdtAlias)().FirstOrDefault()
                        If [alias] IsNot Nothing Then
                            If sdt.ToString() = "DocumentFormat.OpenXml.Wordprocessing.SdtRun" Then
                                Dim xStdRun As SdtRun = DirectCast(sdt, SdtRun)
                                Dim xStdContentRun As SdtContentRun = xStdRun.Descendants(Of SdtContentRun)().FirstOrDefault()
                                Dim xRun As Run = xStdContentRun.Descendants(Of Run)().FirstOrDefault()
                                Dim xText As Text = xRun.Descendants(Of Text)().FirstOrDefault()
                                Dim sdtTitle As String = [alias].Val.Value
                                xText.Text = dictReplacements.Item(sdtTitle)
                            ElseIf sdt.ToString() = "DocumentFormat.OpenXml.Wordprocessing.SdtBlock" Then
                                Dim xStdBlock As SdtBlock = DirectCast(sdt, SdtBlock)
                                Dim xStdContentBlock As SdtContentBlock = xStdBlock.Descendants(Of SdtContentBlock)().FirstOrDefault()
                                Dim xRun As Run = xStdContentBlock.Descendants(Of Run)().FirstOrDefault()
                                Dim xText As Text = xStdContentBlock.Descendants(Of Text)().FirstOrDefault()
                                Dim sdtTitle As String = [alias].Val.Value
                                xText.Text = dictReplacements.Item(sdtTitle)
                            End If
                        End If
                    Next
                    mainPart.Document.Save()
                    document.Close()
                End Using
