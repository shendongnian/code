    private void button1_Click(object sender, EventArgs e)
    {
        List<Control> controls = new List<Control>();
        Type formtype = typeof(Form);
        foreach (Type type in Assembly.GetExecutingAssembly().GetTypes())
        {
            if (formtype.IsAssignableFrom(type))
            {
                Form frm = (Form)Activator.CreateInstance(type);
                controls.Add(frm);//Add the new instance itself to the list
                foreach (Control cntrl in frm.Controls)
                {
                    controls.Add(cntrl);
                }
                frm.Show();//show the new form created
            }
        }
        listBox1.DataSource = controls;
        listBox1.DisplayMember = "Name";//or "Text"
    }
