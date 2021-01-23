           private void btnLoad_Click(object sender, EventArgs e)
        {
            //to load the first chosen months data
            this.beginningCountTableAdapter.Fill(this.beginningDataSet.BeginningCount, Convert.ToInt32(storeAccountComboBox.Text), Convert.ToDateTime(dateTimePicker1.Text));
            //to load the second chosen months data
            this.endingCountTableAdapter.Fill(this.endingDataSet.EndingCount, Convert.ToInt32(storeAccountComboBox.Text), Convert.ToDateTime(dateTimePicker2.Text));
            //Create new DataTable
            DataTable dtItems = new DataTable();
            //add columns to the dataTable
            dtItems.Columns.Add("Product", typeof(string));
            dtItems.Columns.Add("Beginning", typeof(decimal));
            dtItems.Columns.Add("Purchases", typeof(int));
            dtItems.Columns.Add("Ending", typeof(decimal));
            //Add a new Column to Calculate the Value
            dtItems.Columns.Add("Total Gone (Usage)", typeof(decimal)); 
            //add more columns for $ value
            dtItems.Columns.Add("Beginning$", typeof(decimal));
            dtItems.Columns.Add("Purchases$", typeof(decimal));
            dtItems.Columns.Add("Ending$", typeof(decimal));
            //Add a new Column to Calculate the Value
            dtItems.Columns.Add("Total Gone ($)", typeof(decimal));
            dtItems.Columns.Add("% of Sales", typeof(decimal));
            try
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    //first column
                    string product = Convert.ToString(dataGridView1.Rows[i].Cells[0].Value);
                    //calculation for TotalGone (usage)
                    decimal beginning = Convert.ToDecimal(dataGridView1.Rows[i].Cells[1].Value);
                    decimal purchases = Convert.ToDecimal(dataGridView2.Rows[i].Cells[0].Value);
                    decimal ending = Convert.ToDecimal(dataGridView2.Rows[i].Cells[1].Value);
                    decimal totalGone = ((beginning + purchases) - ending);
                    //Variables for conversions for $ column math
                    decimal beg = Convert.ToDecimal(dataGridView1.Rows[i].Cells[1].Value);
                    decimal begPrice = Convert.ToDecimal(dataGridView1.Rows[i].Cells[2].Value);
                    decimal begValue = beg * begPrice;
                    decimal pur = Convert.ToDecimal(dataGridView2.Rows[i].Cells[0].Value);
                    decimal purPrice = Convert.ToDecimal(dataGridView2.Rows[i].Cells[2].Value);
                    decimal purValue = pur * purPrice; 
                    decimal end = Convert.ToDecimal(dataGridView2.Rows[i].Cells[1].Value);
                    decimal endPrice = Convert.ToDecimal(dataGridView2.Rows[i].Cells[2].Value);
                    decimal endValue = end * endPrice;
                    decimal totalGoneValue = ((beg * begPrice) + (pur * purPrice)) - (end * endPrice);
                    totalGoneColumnTotal = totalGoneColumnTotal + totalGoneValue; //The total of all product totalGoneValues
                    decimal salesPercentage = 0; //The sales percentage
                    thirtyPercent = Convert.ToDecimal(txtThirtyPct.Text); //the thirty percent discount txt entry
                    double chickenValue = Convert.ToDouble(dataGridView2.Rows[28].Cells[0].Value);
                    chickenRebate = (chickenValue * .512);
                    double steakValue = Convert.ToDouble(dataGridView2.Rows[29].Cells[0].Value);
                    steakRebate = steakValue * .550; 
                    totalWithRebates = (Convert.ToDouble(totalWithDiscount) - ((chickenRebate + steakRebate)));
                    try
                    {
                        decimal sales = Convert.ToDecimal(textSales.Text); //convert the sales entry
                        salesPercentage = totalGoneValue / sales * 100; //find sales percentage
                        totalWithDiscount = totalGoneColumnTotal - thirtyPercent; //find thirtypercent discount amount
                    }
                    catch { MessageBox.Show("The sales entry must be a number between 1 and 999999.99");
                    break;
                    }
                    //add colors to the output. 
                    
                    //Add rows to the DataTable
                    dtItems.Rows.Add(product, beginning, purchases, ending, totalGone, begValue, purValue, endValue, totalGoneValue, salesPercentage);                
                }//end for
                
                //Totals Summary Rows
                dtItems.Rows.Add("Totals", null, null, null, null, null, null, null, totalGoneColumnTotal, null);
                dtItems.Rows.Add("30% discounts",  null, null, null, null, null, null, null, thirtyPercent ,null);
                dtItems.Rows.Add("Total w/discount", null, null, null, null, null, null, null, totalWithDiscount, null);
                dtItems.Rows.Add("Chicken Rebate x * 5.12", null, null, null, null, null, null, null, chickenRebate, null);
                dtItems.Rows.Add("Steak Rebate x * 5.50", null, null, null, null, null, null, null, steakRebate, null);
                dtItems.Rows.Add("Total w/Rebates", null, null, null, null, null, null, null, totalWithRebates, null);
                //Set the DataTable as DataSource of the GridView
                dataGridView3.DataSource = dtItems;
            }
            catch { MessageBox.Show("Could not determine values. There may be no data for this date range/store."); }
