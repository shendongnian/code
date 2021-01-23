     protected void TestDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Image i = this.TestImage;
            i.ImageUrl = String.Format("http://someplace.com?variable={0}", ((DropDownList)sender).SelectedValue);
        }
