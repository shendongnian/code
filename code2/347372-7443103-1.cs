            public List<Income> AdditionalIncomeList 
            {
                get { return ViewState["AdditionalIncome"] as List<Income>; }
                set { ViewState["AdditionalIncome"] = value; }
            }                
                foreach (RepeaterItem item in AddIncomeSources.Items)
                {
                    var amount = (TextBox)item.Controls.Cast<Control>().First(c => c.ID == "Amount");
                    var document = (DropDownList)item.Controls.Cast<Control>().First(c => c.ID == "Document");
                    AdditionalIncomeList[item.ItemIndex].Amount = amount.Text.ToDouble();
                    AdditionalIncomeList[item.ItemIndex].IncomeDocument = document.SelectedValue;
                }
                AddIncomeSources.DataSource = AdditionalIncomeList;
                AddIncomeSources.DataBind();
