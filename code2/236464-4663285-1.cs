        private void BindData(Dictionary<int, string> dict){
            this.rep.ItemDataBound += new RepeaterItemEventHandler(rep_ItemDataBound);
            this.rep.DataSource = dict;
            this.rep.DataBind();   
        }
        void rep_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                KeyValuePair<int, string> kp = e.Item.DataItem as KeyValuePair<int, string>;
                //... find the control and update it with the correct values
            }
        }
