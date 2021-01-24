    private void LoadBoard_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (LoadBoard.SelectedIndex != -1)
            {
                //Load model
                ViewModel SelectedItem = (ViewModel)LoadBoard.SelectedItem;
                Load loadModel = HOTLOADEntity.Loads.Find(SelectedItem.bol_num);
                using (HOTLOADDBEntities HOTLOADEntity = new HOTLOADDBEntities())
                {
                    loadModel = HOTLOADEntity.Loads.Where(x => x.bol_num == loadModel.bol_num).FirstOrDefault();
                    bol_txt.Text = loadModel.bol_num.ToString();
                    loadStatus_cmbo.SelectedIndex = ParseStatus(loadModel.load_status);
                    pro_txt.Text = loadModel.pro_num.ToString();
                    quote_txt.Text = loadModel.quote_num.ToString();
                    ref_txt.Text = loadModel.ref_num.ToString();
                    weight_txt.Text = loadModel.weight.ToString();
                    pieces_txt.Text = loadModel.pieces.ToString();
                    commodity_txt.Text = loadModel.commodity.ToString();
                    mileage_txt.Text = loadModel.mileage.ToString();
                    carrierRate_txt.Text = loadModel.carrier_rate.ToString();
                    customerRate_txt.Text = loadModel.customer_rate.ToString();
                    //Dates & Times
                    pickDate_picker.Text = loadModel.pick_date.ToString();
                    pickAptTime_txt.Text = TimeStringBuilder(loadModel.pick_time.Value);
                    dropDate_picker.Text = loadModel.drop_date.ToString();
                    dropAptTime_txt.Text = TimeStringBuilder(loadModel.drop_time.Value);
                    driver_txt.Text = loadModel.driver_id.ToString();
                    dispatch_txt.Text = loadModel.dispatch_id.ToString();
                    customer_txt.Text = loadModel.customer_id.ToString();
                    broker_txt.Text = loadModel.broker_id.ToString();
                    lastUpdated_lbl.Content = "Last Updated: " + loadModel.last_updated_time;
                }
                //Change Update/New button text
                update_btn.Content = "Update Load";
                //Enable copy & delete buttons
                delete_btn.IsEnabled = true;
                copy_btn.IsEnabled = true;
            }
        }
