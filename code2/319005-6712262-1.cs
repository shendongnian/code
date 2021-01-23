    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Data.SqlClient;
    using System.Configuration;
    using System.Data;
   
    public partial class codebehind : System.Web.UI.Page 
    {
    //DECLARATIONS    
    string selectedvalue;
    List<string> createdckbxs = new List<string>();
    List<string> CheckedCheckboxes = new List<string>();
    CheckBox ckbx;
    int ckbxID = 0;
    //END DECLARATIONS
    protected void Page_Load(object sender, EventArgs e)
    {
        
        Response.Write(DateTime.Now); //local time -- testing
        Response.Write("<br /><br />NOTE: the id feild in the below table will be useless soon, it is only for testing purposes, look at CRM<br /><br />");
        selectedvalue = Request.QueryString["filter"];
        //88888888888888888
        RecreatePreviousState();
        //88888888888888888
        Response.Write(selectedvalue);
        instructionsfunc();
    }
    protected void instructionsfunc()
    {
        switch (selectedvalue)
        {
            case "Name":
                instructions.Text = "Please enter the first few letters of the company you are looking for, ex. for "some company", you might search som";
                break;
            case "State":
                instructions.Text = "Please enter the abreviation of the state you are looking for, ex. for New York, enter NY";
                break;
        }
    }
    
    protected string sqlSelector(string uinput)
    {
        switch (selectedvalue) //create the sql statments
        {
            case "Name":          
                return "SELECT [id],[name] FROM [asd].[jkl] WHERE [name] LIKE '" + uinput + "%' and [deleted] = 0 ORDER BY [name] ASC";  
            case "State":
                return "SELECT [id],[name] FROM [asd].[jkl] WHERE [shipping_address_state] LIKE '" + uinput + "%' and [deleted] = 0 ORDER BY [name] ASC";
            default:
                Response.Redirect("errorpage.aspx?id=002");
                return null; 
        }
    }
    //on Submit button click, execute the following function NOTE THIS BUTTON's ONLY USE IS POSTBACK
    protected void Submit_Click(object sender, EventArgs e)
    {
        string Userinput; //declare Userinput variable
        Userinput = Searchbox.Value; // Set variable to asp controll        
        Response.Write("<br /> <br />"+ Userinput +" <- user imput works");
    }
    //on Clear button click execute the following function
    protected void Clear_Click(object sender, EventArgs e)
    {
        Response.Redirect(Request.RawUrl);
    }
  
    protected void ConnectToSql(string input)
    {
        System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();
        //Todo add any aditional data needed to connection
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["SplendidTestConnectionString"].ConnectionString;
        try
        {
            conn.Open();
            
            //this is the actual sql, this gets the data
            SqlCommand sqlString2 = new SqlCommand();
            sqlString2.CommandText = sqlSelector(input);
            sqlString2.CommandTimeout = 15;
            sqlString2.CommandType = System.Data.CommandType.Text;
            sqlString2.Connection = conn;
            SqlDataReader reader;
            reader = sqlString2.ExecuteReader();
            table_builder(reader);
           
                     
            reader.Close(); //close the sql data reader
            
        
        }
        catch (Exception e)
        {
            //Some sort of redirect should go here to prevent the user from vewing a broken page
            conn.Close();
            //Response.Redirect("errorpage.aspx?id=001");
            Response.Write(e);
        }
        finally
        {
            if (conn.State != System.Data.ConnectionState.Closed)
            {
                conn.Close();//close up the connection after all data is done being populated
            }
        }
    }
    protected void  table_builder(SqlDataReader readerinfo)
    {
        //Create a new step for the user
        step3label.Text = "3.";
        //Table header
        TableHeaderRow hr = new TableHeaderRow();
        TableHeaderCell hc = new TableHeaderCell();
        TableHeaderCell hc2 = new TableHeaderCell();
        TableHeaderCell hc3 = new TableHeaderCell();
        hr.Cells.Add(hc);
        hc.Text = "ID"; //Assign header 1 with a name
        hr.Cells.Add(hc2);
        hc2.Text = "Name";//Assign header 2 with a name
        hr.Cells.Add(hc3);
        hc3.Text = "Selection";
        Table1.Rows.Add(hr);
        //Dynamic Table Generation
        int numcells = 3;
        int triswitch = 0;//this is use to chose which cell is made, id, name or selection
                
        while (readerinfo.Read())   //execute the following aslong as there is data to fill the table with
        {
            for (int j = 0; j < 1; j++)
            {
                TableRow r = new TableRow();
                for (int i = 0; i < numcells; i++)
                {
                    TableCell c = new TableCell();
                    switch (triswitch)
                    {
                        case 0: // this case sets the info for the feild id
                            c.Text = readerinfo.GetSqlGuid(0).ToString();
                            //RENAME THIS To ADDING BUTTON = readerinfo.GetSqlGuid(0).ToString();
                            r.Cells.Add(c);
                            triswitch = 1;
                            break;
                        case 1:
                            c.Text = readerinfo.GetString(1);
                            r.Cells.Add(c);
                            triswitch = 2;
                            break;
                        case 2:
                            ckbx = new CheckBox();
                            ckbx.ID = "CBX" + ckbxID;
                            createdckbxs.Add(ckbx.ID);
                            c.Controls.Add(ckbx);                           
                            r.Cells.Add(c);
                            triswitch = 0;
                            ckbxID++;
                            break;
                    }
                }
                Table1.Rows.Add(r);
            }
        }
    }
    
    //
    //AFTER DATATABLE IS LOADED
    //   
    protected void RecreatePreviousState()
    {
        if (this.IsPostBack)
        {
            ConnectToSql(Searchbox.Value);
            MergeBtnCreate();
        }       
    }
    protected void MergeBtnCreate()
    {
        Button MergeBTN = new Button();
        MergeBTN.Text = "Merge";
        MergeBTN.Click += new EventHandler(MergeBTN_Click);
        MergeBTNHolder.Controls.Add(MergeBTN);
    }
    void MergeBTN_Click(object sender, EventArgs e)
    {
        foreach(string id in createdckbxs)
        {
            CheckBox myControl1 = (CheckBox)Table1.FindControl(id);
            if (myControl1 != null)
            {
                if (myControl1.Checked == true)
                {
                    CheckedCheckboxes.Add(id);
                }
            }
            else
            {
                Response.Redirect("errorpage.aspx?id=003");
            }
        }
    }
    }
