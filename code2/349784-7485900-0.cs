    private void Form1_Load(object sender, EventArgs e)
            {
                List<randomClass> lst = new List<randomClass>();
    
                lst.Add(new randomClass());
                lst.Add(new randomClass());
                lst.Add(new randomClass());
                lst.Add(new randomClass());
                lst.Add(new randomClass());
                lst.Add(new randomClass());
    
                ((ListBox)this.checkedListBox1).DataSource = lst;
                ((ListBox)this.checkedListBox1).DisplayMember = "Name";
                ((ListBox)this.checkedListBox1).ValueMember = "IsChecked";
    
    
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    randomClass obj = (randomClass)checkedListBox1.Items[i];
                    checkedListBox1.SetItemChecked(i, obj.IsChecked);
                }
            }
        }
    
        public class randomClass
        {
            public bool IsChecked { get; set; }
            public string Name { get; set; }
            public randomClass()
            {
                this.IsChecked = true;
                Name = "name1";
            }
        }
