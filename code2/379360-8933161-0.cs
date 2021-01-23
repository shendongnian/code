     public void backgroundWorkerPinger_DoWork(object sender, DoWorkEventArgs e)
            {
               
                Ping ping = new Ping();
            
                    try
                    {
                        PingReply pingreply = ping.Send("46.4.106.10", 500);
                        string active = pingreply.Status.ToString();
                        if (active == "Success")
                        {
                            //Pokud je spojení aktivni pak se nastavi barva labelu na zelenou a vypise se aktivni
                            ActiveOrNotLabel.ForeColor = Color.Green;
                            ActiveOrNotLabel.Text = "Aktivní";
                           // MessageBox.Show("vyjimka2");
                            if (connection_enabled == false)
                            {
                                admini.Enabled = true;
                                connection_enabled = true;
                            }
                        }
                        if (active != "Success") {
                            ActiveOrNotLabel.ForeColor = Color.Red;
                            ActiveOrNotLabel.Text = "Neaktivní";
                            admini.Enabled = false;
                            connection_enabled = false;
                            
                         }
                    }
                    catch
                    {
                        //Jinak na cervenou a neaktivni
    
                        //MessageBox.Show("vyjimka");
                        ActiveOrNotLabel.ForeColor = Color.Red;
                        ActiveOrNotLabel.Text = "Neaktivní";
                        admini.Enabled = false;
                        connection_enabled = false;
    
                    }
                }
