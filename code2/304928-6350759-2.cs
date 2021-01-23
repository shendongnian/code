        protected void Page_Load(object sender, EventArgs e)
        {
            //Wire up the event to handle when items are bound to the repeater
            this.myRepeater.ItemDataBound += new RepeaterItemEventHandler(myRepeater_ItemDataBound);
            //Now actually bind the categories to the repeater
            this.myRepeater.DataSource = GetCategories(MyBusinessObjects);
            this.myRepeater.DataBind();
        }
        void myRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            //Don't process items that are not item, or alternating item
            if (!(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)) return;
            //Grab a reference to the checkboxlist in our repeater
            CheckBoxList checkboxlist = (CheckBoxList)e.Item.FindControl("checkboxlist");
            //Now put our business objects of that category in it
            checkboxlist.DataSource = GetItemsFromCategory(MyBusinessObjects, (string)e.Item.DataItem);
            checkboxlist.DataBind();
        }
        //Helper to grab categories.
        private IEnumerable<string> GetCategories(IEnumerable<BusinessObject> items)
        {
            return (from i in items
                    select i.Category).Distinct();
        }
        //Helper to grab the items in categories.
        private IEnumerable<BusinessObject> GetItemsFromCategory(IEnumerable<BusinessObject> items, string category)
        {
            return (from i in items
                    where i.Category == category
                    select i);
        }
