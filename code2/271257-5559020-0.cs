    Position1TableAdapter position1TableAdapter =
                    new Position1TableAdapter();
                HumanResource.Position1Row posRow =
                    position1TableAdapter.GetData(Convert.ToInt32(Request.QueryString["PositionID"]))[0];
                DDL_Assignment.DataTextField = "AssignmentName";
                DDL_Assignment.DataValueField = "AssignmentName";
                DDL_Assignment.DataSourceID = "DataSource_Assignment";
                DDL_Occupation.DataBind();
                DDL_Occupation.SelectedValue = posRow.Position;
                DDL_Assignment.DataBind();
                DDL_Assignment.SelectedValue = posRow.Assignment;
                TB_Replaced.Text = posRow.IsReplacedNull() ? null : posRow.Replaced;
                DDL_PositionDays.DataBind();
                DDL_PositionDays.SelectedValue = posRow.PositionDays.ToString();
                DDL_ContractDays.DataBind();
                DDL_ContractDays.SelectedValue = posRow.ContractDays.ToString();
                DDL_PositionHours.DataBind();
                DDL_PositionHours.SelectedValue = posRow.PositionHours.ToString();
