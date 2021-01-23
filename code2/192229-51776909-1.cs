    CSS
        	.div-no-display {
    		display: none;
    	}
    Code Behind - Usually don't bind it if its empty in that case you have to put the div outside the repeater, but if you bind 0 items you can put it in the header template
        this.Repeater.DataSource = ChildLinksList;
    							this.Repeater.DataBind();
    
        public List<Link> ChildLinksList { get; set; }
    Page                   
        <HeaderTemplate>
    	<div id="NoRecords" class='<%= ChildLinksList.Count > 0 ? "div-no-display" : "" %>'>
    		 No child links active.
    	</div>
    </HeaderTemplate>
