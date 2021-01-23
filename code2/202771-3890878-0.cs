    This aspx page code
    
            <asp:Repeater ID="rptImages" runat="server" onitemcommand="rptImages_ItemCommand">
                  <ItemTemplate >           
                         <div class="image"> <a ><asp:Image ID="Image1" runat="server" imageUrl=' <%# Eval("ImageUrl") %>'  /></a> </div>        
                   </ItemTemplate>            
               </asp:Repeater>                    
            			
        
            <asp:Repeater ID="rptPages" Runat="server" 
                                onitemcommand="rptPages_ItemCommand">
                  <HeaderTemplate>
                  <table cellpadding="0" cellspacing="0" border="0">
                  <tr class="text">
                     <td><b style="color:White;">Page:</b>&nbsp;</td>
                     <td>
                  </HeaderTemplate>
                  <ItemTemplate>
                     <asp:LinkButton ID="btnPage" ForeColor="White"
                                     CommandName="Page"
                                     CommandArgument="<%#
                                     Container.DataItem %>"
                                     CssClass="text"
                                     Runat="server"><%# Container.DataItem %>
                                     </asp:LinkButton>&nbsp;
                  </ItemTemplate>
                  <FooterTemplate>
                     </td>
                  </tr>
                  </table>
                  </FooterTemplate>
              </asp:Repeater>	                   
        				                   
        
    
    this code behind page code
            public void LoadData()
                {
                    try
                    {
                        PagedDataSource pgitems = new PagedDataSource();
                        DataView dv = new DataView(dtImage);
                        pgitems.DataSource = dv;
                        pgitems.AllowPaging = true;
                        pgitems.PageSize = 8;
                        pgitems.CurrentPageIndex = PageNumber;
                        if (pgitems.PageCount > 1)
                        {
                            rptPages.Visible = true;
                            ArrayList pages = new ArrayList();
                            for (int i = 0; i < pgitems.PageCount; i++)
                                pages.Add((i + 1).ToString());
                            rptPages.DataSource = pages;
                            rptPages.DataBind();
                        }
                        else
                            rptPages.Visible = false;
                        rptImages.DataSource = pgitems;
                        rptImages.DataBind();
                    }
                    catch { }
                }		
        
        public int PageNumber()
            {
                
                get
                {
                    if (ViewState["PageNumber"] != null)
                        return Convert.ToInt32(ViewState["PageNumber"]);
                    else
                        return 0;
                }
                set
                {
                    ViewState["PageNumber"] = value;
                }
            }
        
        		public void itemGet()
        {
            try
            {
                var Images = dataContext.sp_getCards(categoryId);
        
                PagedDataSource pds = new PagedDataSource();
                pds.DataSource = Images;
                pds.AllowCustomPaging = true;
                pds.AllowPaging = true;
                pds.PageSize = 8;
        
                pds.CurrentPageIndex = CurrentPage;
        
                lblCurrentPage.Text = "Page: " + (CurrentPage + 1).ToString() + " of "
                    + pds.PageCount.ToString();
        
        
                // Disable Prev or Next buttons if necessary
                //cmdPrev.Enabled = !pds.IsFirstPage;
                //cmdNext.Enabled = !pds.IsLastPage;
        
                rptImages.DataSource = pds;
                rptImages.DataBind();
            }
            catch { }
        
        }
        
        
        protected void rptPages_ItemCommand(object source, RepeaterCommandEventArgs e)
            {
                try
                {
                    PageNumber = Convert.ToInt32(e.CommandArgument) - 1;
                    LoadData();
                }
                catch { }
            }
