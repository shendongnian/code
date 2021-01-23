    private void BindingLIstDemo_Load(object sender, EventArgs e)
            {
                InitializeListOfEmployees();
                BindlstEmp();
                listofEmp.AddingNew += new AddingNewEventHandler(listOfEmp_AddingNew);
                listofEmp.ListChanged += new ListChangedEventHandler(listofEmp_ListChanged);
                
            }
    
            private void BindlstEmp()
            {
                lstEmpList.Items.Clear();
                lstEmpList.DataSource = listofEmp;
                lstEmpList.DisplayMember = "Name";
    
            }
    
            void listofEmp_ListChanged(object sender, ListChangedEventArgs e)
            {
                MessageBox.Show(e.ListChangedType.ToString());
                    //throw new NotImplementedException();
            }
    
            //declare list of employees
            BindingList<Emp> listofEmp;
            private void InitializeListOfEmployees()
            {
    
                //throw new NotImplementedException();
                // Create the new BindingList of Employees.
                listofEmp = new BindingList<Emp>();
                
                // Allow new Employee to be added, but not removed once committed.
                listofEmp.AllowNew = true;
                listofEmp.AllowRemove = true;
    
                // Raise ListChanged events when new Employees are added.
                listofEmp.RaiseListChangedEvents = true;
    
                // Do not allow Employee to be edited.
                listofEmp.AllowEdit = false;
    
                listofEmp.Add(new Emp(1, "Niranjan", 10000));
                listofEmp .Add (new Emp (2,"Jai", 8000));
               
              }
    
            
            // Create a new Employee from the text in the two text boxes.
            void listOfEmp_AddingNew(object sender, AddingNewEventArgs e)
            {
                e.NewObject = new Emp (Convert.ToInt32(txtId.Text), txtName.Text,Convert.ToInt32(txtSalary.Text));
    
            }
    
            private void btnAdd_Click(object sender, EventArgs e)
            {
                Emp empItem = listofEmp.AddNew();
                txtId.Text = txtName.Text = txtSalary.Text = "";
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                Form1 obj = new Form1();
                obj.Show();
            }
    
            private void btnDelete_Click(object sender, EventArgs e)
            {
                var sg = (from sc in listofEmp.ToList<Emp>() where sc.Name == ((Emp)lstEmpList.SelectedValue).Name select sc);
    
                
                
                
                
            }
    
            private void lstEmpList_SelectedIndexChanged(object sender, EventArgs e)
            {
                Emp se = listofEmp[lstEmpList.SelectedIndex];
                txtId.Text = se.Id.ToString();
                txtName.Text = se.Name;
                txtSalary.Text = se.Salary.ToString();
    
            }
