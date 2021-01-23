    using( Form2 frm = new Form2() )
    {
        if( frm.ShowDialog() == DialogResult.OK )
        {
            Person p = frm.Person;
            list.Items.Add( p.Name );
            lblName.Text = p.Name;
            lblPhone.Text = p.PhoneNumber;
            lblName.City = p.City;
        }
    }
