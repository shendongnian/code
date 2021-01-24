    r => new MyClass
                            {
                                UserFullName = (string)r.Properties["UserFullName"].Value,
                                BrokeringTime = (DateTime)r.Properties["BrokeringTime"].Value,
                                ClientName = (string)r.Properties["ClientName"].Value,
                                DesktopGroupName = (string)r.Properties["DesktopGroupName"].Value,
                                //SessionState = (string)r.Properties["SessionState"].Value,
                                Uid = (Int64)r.Properties["Uid"].Value,
                                //MachineName = (string)r.Properties["MachineName"].Value,
                                //ENV = (string)r.Properties["ENV"].Value,
                            }
                        );
                    this.ResultGrid.DataSource = objects;
                    this.ResultGrid.DataBind();
                }
    
                }
    
            protected void ResultGrid_SelectedIndexChanged(object sender, EventArgs e)
            {
    
                Response.Write(ResultGrid.SelectedValue.ToString());
    
            }
        }
    
        internal class MyClass
        {
            public string UserFullName { get; set; }
            public DateTime BrokeringTime { get; set; }
            public string ClientName { get; set; }
            public string DesktopGroupName { get; set; }
            public String SessionState { get; set; }
            public Int64 Uid { get; set; }
            public string MachineName { get; set; }
            public string ENV { get; set; }
        }
