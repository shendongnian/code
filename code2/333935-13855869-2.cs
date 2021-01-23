    private void GenerateList()
        {
            if (Session["People"] != null)
            {
                List<Address> people = (List<Address>)Session["People"];
                Address a1 = new Address();
                a1.DoorNo = txtDoorno.Text;
                a1.StreetName = txtStreetName.Text;
                a1.City = txtCityname.Text;
                a1.PhoneNo = txtPhoneno.Text;
                people.Add(a1);
                Session["People"] = people;
                grdShow.DataSource = people;
                grdShow.DataBind();
            }
        }
