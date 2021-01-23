    private void button1_Click(object sender, EventArgs e)
    {
        Type formtype = typeof(Form);
        foreach (Type type in Assembly.GetExecutingAssembly().GetTypes())
        {
            if (formtype.IsAssignableFrom(type))
            {
                Form frm = (Form)Activator.CreateInstance(type);
                listBox1.Items.Add(frm);//Add the new instance itself to the list
                foreach (Control cntrl in frm.Controls)
                {
                    listBox1.Items.Add(cntrl);
                }
                frm.Show();//show the new form created
            }
        }
    }
