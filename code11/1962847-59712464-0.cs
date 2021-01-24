        private void BtnSearch_Click(object sender, EventArgs e)
                {
                    string sql = @" SELECT [Order_Payments].[order_id] as 'Acc No.'
              ,order_vat as 'VAT value'
        	  ,vat_orders.[total_amount] as 'Total After VAT'
        	  ,[Order_Payments].paid_amount as 'Total Paid'
              ,[remaining_amount]
        	  ,vat_orders.order_date 
              ,Customers.CustName as 'Clinic'
           
          FROM [Order_Payments]
          inner join vat_orders on  [Order_Payments].order_id = vat_orders.ORDER_ID
          inner join Customers on  [Order_Payments].custid = Customers.CustId
          WHERE cast(vat_orders.order_date as time) between '01:00:00' and '23:50:50' ";
        
                        string condition = "";
                        string orderby = "";
                        orderby += " ORDER BY Order_Payments.order_id";
        
                        DateTime fromDate;
                        DateTime toDate;
                       
        
                        if (!DateTime.TryParse(dtFromDate.Value.ToString(), out fromDate))
                        {
                            System.Windows.Forms.MessageBox.Show("Invalid From Date");
                        }
                        else if (!DateTime.TryParse(dtToDate.Value.ToString(), out toDate))
                        {
                            System.Windows.Forms.MessageBox.Show("Invalid to Date");
                        }
                        else
                        {
                            condition += " and cast(vat_orders.order_date as date) between '" + fromDate + "' and '" + toDate + "'";
                        }
                
    
    if (textCustId.Text != "")
                {
                    condition += " and Order_Payments.CUSTID ='" + textCustId.Text + "'";
                }
    
    
                DataTable dt = data.fireDatatable(string.Format(sql + condition + orderby));
                OrdersDataGridView.DataSource = dt;
                OrdersDataGridView.Refresh();
        }
