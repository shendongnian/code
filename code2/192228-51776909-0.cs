    CSS
        	.div-no-display {
    		display: none;
    	}
    Code Behind
        this.Repeater.DataSource = ChildLinksList;
    							this.Repeater.DataBind();
    
        public List<Link> ChildLinksList { get; set; }
    Page                   
        <HeaderTemplate>
    	<div id="NoRecords" class='<%= ChildLinksList.Count > 0 ? "div-no-display" : "" %>'>
    		 No child links active.
    	</div>
    </HeaderTemplate>
