    <asp:Button  runat="server" ID="hiddenTargetControlForTabContainer" style="display:none" />
    <asp:UpdatePanel ID="TabContainerUpdatePanel" runat="server">
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="hiddenTargetControlForTabContainer" />
    </Triggers>
    <ContentTemplate>
          <asp:HiddenField ID="TabContainerActiveTab" runat="server" Value="0" />   
          <AjaxControlToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0"
                                           OnClientActiveTabChanged="OrderTabContainerClientActiveTabChanged"   >
                  
                <AjaxControlToolkit:TabPanel runat="server" ID="TabPanel1" 
                                             HeaderText="TabPanel1"
                                              >
                    <ContentTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                            
                   
                    </ContentTemplate>
                </AjaxControlToolkit:TabPanel>
                <AjaxControlToolkit:TabPanel  runat="server" ID="TabPanel2" 
                                              HeaderText="TabPanel2" >
                    <ContentTemplate>
                 
                                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                           
                    </ContentTemplate>
                </AjaxControlToolkit:TabPanel>
            </AjaxControlToolkit:TabContainer>
    </ContentTemplate>
    </asp:UpdatePanel>
    
    <script type="text/javascript">
        var TabContainerActiveTabControlID = '<%= TabContainerActiveTab.ClientID %>';
        var hiddenTargetControlForTabContainerControlID = '<%= hiddenTargetControlForTabContainer.uniqueID %>';
        function OrderTabContainerClientActiveTabChanged(sender, args) {
            var TabContainerActiveTabControl = $get(TabContainerActiveTabControlID);
            var OldtabIndex = parseInt(TabContainerActiveTabControl.value);
            var NewtabIndex = sender.get_activeTabIndex();
            if (!(OldtabIndex == NewtabIndex)) {
                sender.set_activeTabIndex(OldtabIndex);
                TabContainerActiveTabControl.value = NewtabIndex;
                __doPostBack(hiddenTargetControlForTabContainerControlID, '');
            }
        }
