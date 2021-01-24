    public partial class workPlacePlan : Form
        {
    
            public workPlacePlan()
            {
                InitializeComponent();
            }
    
            private void workPlacePlan_Load(object sender, EventArgs e)
            {
                this.MaximumSize = this.Size;
                this.MinimumSize = this.Size;
    
                int cboId;
                int i = 1;
            
                string cboName; int c = 1;
                var items = new Dictionary<int, string>();
    
                ComboBox[] cbo = {
                    cbo_1_0, cbo_1_1, cbo_2_0, cbo_2_1, cbo_3_0, cbo_3_1, cbo_4_0, cbo_4_1, cbo_5_0, cbo_5_1, cbo_6_0, cbo_6_1,                
                    cbo_13_0,cbo_13_1,cbo_14_0,cbo_14_1,cbo_15_0,cbo_15_1,cbo_16_0,cbo_16_1,cbo_17_0,cbo_17_1,cbo_18_0,cbo_18_1,
                    cbo_19_0,cbo_19_1
                };
    
                foreach(ComboBox cbos in cbo)
                {
                    items.Add(0, "-------");
                    i = 1;
                    while (i <= 24)
                    {
                        cboId = i;
                        cboName = TimeSpan.FromHours(i).ToString("hh':'mm");
    
                        items.Add(cboId, cboName);
                        i++;
                    }
                    cbos.Tag = c;
                    cbos.DataSource = new BindingSource(items, null);
                    cbos.DisplayMember = "Value";
                    cbos.ValueMember = "Key";
                    cbos.SelectedIndex = 0;
                    items.Clear();
    
                    cbos.SelectedIndexChanged += new EventHandler(cboSelected);
    
                    c++;
    
                }
               
            }
    
            public void cboSelected(object sender, EventArgs e)
            {
                ComboBox cb = ((ComboBox)sender);
                int i_tmp;
                int tg = Int32.Parse(cb.Tag.ToString());
                int idx;
    
                if(tg % 2 == 0) //if is even
                {
                    i_tmp= tg - 1;
                }
                else
                {
                    i_tmp = tg + 1;
                }
    
                //string y = cb.GetItemText(cb.SelectedItem);
                //MessageBox.Show(y.ToString());
    
                foreach (ComboBox cbt in panel1.Controls.OfType<ComboBox>()) {
                    if(Int32.Parse(cbt.Tag.ToString()) == Int32.Parse(i_tmp.ToString()))
                    {
                        idx = Int32.Parse(cbt.SelectedIndex.ToString());
                        cbt.SelectedIndex = idx;
                        MessageBox.Show(cbt.SelectedIndex.ToString());
                    }   
                }
    
            }
    
            private void cmd_Save_Click(object sender, EventArgs e)
            {
    
            }
        }
