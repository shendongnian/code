			protected void LinkDocRepeaterOnItemDataBound(object sender, RepeaterItemEventArgs e) {
			    if(!(e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)) {
				return;
                    }
                LinkButton linkButton = (LinkButton)e.Item.FindControlRecursive("LinkId");
			    var scriptManager = ScriptManager.GetCurrent(this.Page);
			    if (scriptManager != null) {
				   scriptManager.RegisterPostBackControl(linkButton);
			    }
		    }
