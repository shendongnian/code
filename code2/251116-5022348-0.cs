    <asp:UpdatePanel runat="server" UpdateMode="Conditional">
         <Triggers>
             <asp:AsyncPostBackTrigger ControlID="btnClick" EventName="Click" />
         </Triggers>
         <ContentTemplate>
    
         <asp:GridView ID="GridView1" ...
         YOUR GRID CODE REMAINS THE SAME
         </asp:GridView>
    
        </ContentTemplate>
    </asp:UpdatePanel>
