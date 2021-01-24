SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblFullname](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Fullname] [nchar](30) NULL,
 CONSTRAINT [PK_tblFullname] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
 2. Create Stored Produces
    SET ANSI_NULLS ON
    GO
    
    SET QUOTED_IDENTIFIER ON
    GO
    
    -- =============================================
    -- Author:      <Author, , Name>
    -- Create Date: <Create Date, , >
    -- Description: <Description, , >
    -- =============================================
    CREATE PROCEDURE [dbo].[InsertFullname]
    (
        -- Add the parameters for the stored procedure here
        @Fullname nchar(30)
    )
    AS
    BEGIN
        -- SET NOCOUNT ON added to prevent extra result sets from
        -- interfering with SELECT statements.
        SET NOCOUNT ON
    
        -- Insert statements for procedure here
    	
       Insert into dbo.tblFullname (Fullname) values(@Fullname) 
    END
    GO 
 3. Code
Mywebform.aspx.cs
 public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == true) {
                Label1.Text = ("Great job! Data has  inserted");
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            var connect = new SqlConnection("Server=tcp:jacksqldemo.database.windows.net,1433;Initial Catalog=sqldemo;Persist Security Info=False;User ID=jack;Password=Password0123!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            {
                SqlCommand insert = new SqlCommand("EXEC dbo.InsertFullname @Fullname",connect);
                insert.Parameters.AddWithValue("@Fullname",insertName.Text);
                connect.Open();
                insert.ExecuteNonQuery();
                connect.Close();
                if (IsPostBack) {
                    insertName.Text = "";
                }
            }
        }
    }
Mywebform.aspx.designers.cs
public partial class WebForm1 {
        
        /// <summary>
        /// form1 control.
        /// </summary>
        /// <remarks>
        /// Auto-generated field.
        /// To modify move field declaration from designer file to code-behind file.
        /// </remarks>
        protected global::System.Web.UI.HtmlControls.HtmlForm form1;
        
        /// <summary>
        /// Label1 control.
        /// </summary>
        /// <remarks>
        /// Auto-generated field.
        /// To modify move field declaration from designer file to code-behind file.
        /// </remarks>
        protected global::System.Web.UI.WebControls.Label Label1;
        
        /// <summary>
        /// insertName control.
        /// </summary>
        /// <remarks>
        /// Auto-generated field.
        /// To modify move field declaration from designer file to code-behind file.
        /// </remarks>
        protected global::System.Web.UI.WebControls.TextBox insertName;
        
        /// <summary>
        /// Button1 control.
        /// </summary>
        /// <remarks>
        /// Auto-generated field.
        /// To modify move field declaration from designer file to code-behind file.
        /// </remarks>
        protected global::System.Web.UI.WebControls.Button Button1;
    }
 4. result
[![enter image description here][1]][1]
[![enter image description here][2]][2]
[![enter image description here][3]][3]
  [1]: https://i.stack.imgur.com/bomQC.png
  [2]: https://i.stack.imgur.com/AD94q.png
  [3]: https://i.stack.imgur.com/bQcfQ.png
