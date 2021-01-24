`
if (!IsPostBack)
{
	decimal total = decimal.Parse(txtValorTotal.InnerHtml);
	if (total < 500)
	{
		string val = string.Format("{0:#.00}", Convert.ToDouble(total) * 0.987);
		rblParcelamento.Items.Add(new ListItem("1 x " + string.Format("{0:#.00}", val) + " - Prazo: 7 dias", "1"));
	}
	else
	{
		string val = string.Format("{0:#.00}", Convert.ToDouble(total) * 0.987);
		rblParcelamento.Items.Add(new ListItem("1 x " + string.Format("{0:#.00}", val) + " - Prazo: 28 dias", "1"));
	}
	if (total >= 1000)
	{
		string val = string.Format("{0:#.00}", total / 2);
		rblParcelamento.Items.Add(new ListItem("2 x " + val + " - Prazo: 21/35 ddl", "2"));
	}
	if (total >= 1500)
	{
		string val = string.Format("{0:#.00}", total / 3);
		rblParcelamento.Items.Add(new ListItem("3 x " + val + " - Prazo: 21/28/35 ddl", "3"));
	}
	if (total >= 2000)
	{
		string val = string.Format("{0:#.00}", total / 4);
		rblParcelamento.Items.Add(new ListItem("4 x " + val + " - Prazo: 21/28/35/42 ddl", "4"));
	}
	rblParcelamento.SelectedIndex = 0; //you first need to select your item, in this case, the first one
	//rblParcelamento.SelectedValue = "1"; //this also works
	//rblParcelamento.SelectedItem => this could work if you save a variable with (new ListItem)
}
string rblValue = rblParcelamento.SelectedItem.Value; //then you can get the value of the selected item
`
