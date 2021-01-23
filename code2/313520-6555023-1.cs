    protected override void OnInit(EventArgs e) {
        base.OnInit(e);
    
        this.rptItems += new RepeaterItemEventHandler(rptItems_ItemDatabound);
    }
    
    void Page_Load(object sender, EventArgs e) {
        if(!IsPostback) {
            rptItems.DataSource = ...; // List<BasketObject>
            rptItems.DataBind();
        }
    }
    
    void rptItems_ItemDatabound(object sender, RepeaterItemEventArgs e) {
        BasketControl ucBasket = e.Item.FindControl("ucBasket") as BasketControl;
        BasketObject basket = e.Item.DataItem as BasketObject;
    
        // Use datasource/databind, but you could just as easily use a property/method of BasketControl
        // Like so: ucBasket.LoadBasket(basket);
        ucBasket.DataSource = basket;
        ucBasket.DataBind();
    }
