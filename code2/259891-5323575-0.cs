    //Add macro module
    Microsoft.Vbe.Interop.VBComponent component = this.VBProject.VBComponents
    .Add(Microsoft.Vbe.Interop.vbext_ComponentType.vbext_ct_StdModule);
                        component.CodeModule.AddFromString("Sub Paste_cell()" + Environment.NewLine + "If MsgBox(\"Normal paste operation has been disabled. You are about to Paste Values (cannot be undone), proceed?\", vbQuestion + vbOKCancel, GSAPPNAME) = vbOK Then" + Environment.NewLine + "On Error Resume Next" + Environment.NewLine + "ActiveSheet.PasteSpecial Format:=\"Text\", Link:=False, DisplayAsIcon:=False" + Environment.NewLine + "Selection.PasteSpecial Paste:=xlPasteValues, Operation:=xlNone, SkipBlanks:=False, Transpose:=False" + Environment.NewLine + "End If" + Environment.NewLine + "End Sub");
    //trap paste event
    CommonData.DATASHEET.Application.OnKey("^v", "Paste_cell");
