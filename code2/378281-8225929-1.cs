     protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "cmd")
            {
                TextBox tx = e.Item.FindControl("TextBox1") as TextBox;
                tx.Text = e.CommandArgument.ToString();
            }
        }
