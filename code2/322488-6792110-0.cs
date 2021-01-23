        <asp:CustomValidator ID="customValidatorForCheckboxlist" 
            runat="server"   ErrorMessage="Required Field" ValidationGroup="valSurvey"
       OnServerValidate="CheckifCheckBoxHasMoreItems" SetFocusOnError="true" Display="Dynamic"></asp:CustomValidator>
                		
						
    		 
       
     Protected Sub CheckifCheckBoxHasMoreItems(ByVal sender As Object, ByVal e As ServerValidateEventArgs)
                'This code block is for custom Validator known as customValidatorForCheckboxlist
                Dim count As Integer
                For Each gvrow As GridViewRow In gridview1.Rows
                    'Initialize a New instance of ContextAttributeArtifacts and ContextAttributesArtifactsOpenEnded and Assign Properties to Them.
                    For Each ct As Control In gvrow.Cells(1).Controls
                        If ct.GetType.ToString().Equals("System.Web.UI.WebControls.CheckBoxList") Then
                            Dim _checkboxlist As CheckBoxList = DirectCast(ct, CheckBoxList)
                            For Each ListItem1 As ListItem In _checkboxlist.Items
                                If ListItem1.Selected = True Then
                                    valbool = True
                                    count = count + 1
                                End If
                            Next
                        End If
                    Next
        
                Next
                If count > 2 Then
                    e.IsValid = False
                ElseIf count < 2 Then
                    e.IsValid = True
                End If
            End Sub
