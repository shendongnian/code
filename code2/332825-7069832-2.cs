        public class Workflow : INotifyPropertyChanged
        {
            private Int16 id;
            private string name;
            private string description;       
            private Boolean active;
            private User createdBy;
            private DateTime createDate;
            private List<WFBatch> batches = new List<WFBatch>();
            
            public event PropertyChangedEventHandler PropertyChanged;
            protected void NotifyPropertyChanged(String info)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(info));
                }
            }
            
            public Int16 ID { get { return id; } }
            public string Name { get { return name; } }
            public string Description { get { return description; } }           
            public Boolean Active { get { return active; } }
            public User CreatedBy { get { return createdBy; } }
            public DateTime CreateDate { get { return createDate; } }
            public WFBatch newWFbatch { get { return new WFBatch(this, App.StaticGabeLib.Search.IncludeFamilySrched); } }
            public List<WFBatch> Batches 
            {
                get
                { 
                    // get the latest from SQL 
                    // todo optimize - this for now will a SQL call for all batches here
                    if (batches.Count > 0) return batches;
                    SqlConnection sqlConnRW2 = new SqlConnection(sqlConnStringLibDef);
                    try
                    {
                        sqlConnRW2.Open();
                        SqlCommand sqlCmd2 = new SqlCommand();
                        sqlCmd2.Connection = sqlConnRW2;
                        SqlDataReader rdr;
                        sqlCmd2.CommandText = sqlCmd2.CommandText = "Select [ID] from [wfBch] with (nolock) " + Environment.NewLine +
                            "where [wfID] = '" + ID.ToString() + "'  order by [ID] ";
                        rdr = sqlCmd2.ExecuteReader();
                        while (rdr.Read())
                        {
                            batches.Add(new WFBatch(this, rdr.GetInt16(0)));
                        }
                    }
                    catch (Exception Ex)
                    {
                        Debug.WriteLine(Ex.Message);
                    }
                    finally
                    {
                        sqlConnRW2.Close();
                    }  
                    return batches;
                }
            }
            public Workflow(Int16 ID, string Name, string Description, Boolean Active, User CreatedBy, DateTime CreateDate)
            {
                id = ID;
                name = Name;
                description = Description;
                active = Active;
                createdBy = CreatedBy;
                createDate = CreateDate;
                // WFBatch wfBatch = new WFBatch(this);
                // todo retreive batches
            }          
        }
