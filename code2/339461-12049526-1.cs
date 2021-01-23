    public void getClientNameDropDowndata()
    {
        getConnection = Connection.SetConnection(); // to connect with data base Configure manager
        string ClientName = "Select  ClientName from Client ";
        SqlCommand ClientNameCommand = new SqlCommand(ClientName, getConnection);
        ClientNameCommand.CommandType = CommandType.Text;
        SqlDataReader ClientNameData;
        ClientNameData = ClientNameCommand.ExecuteReader();
        if (ClientNameData.HasRows)
        {
            DropDownList_ClientName.DataSource = ClientNameData;
            DropDownList_ClientName.DataValueField = "ClientName";
            DropDownList_ClientName.DataTextField="ClientName";
            DropDownList_ClientName.DataBind();
        }
        else
        {
            MessageBox.Show("No is found");
            CloseConnection = new Connection();
            CloseConnection.closeConnection(); // close the connection 
        }
    }
