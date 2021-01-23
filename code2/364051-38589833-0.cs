    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.IO;
    using System.Data.SqlClient;
    using System.Configuration;
    using System.Data.Common;
    
    namespace CodeGenerator
    {
        public partial class Form1 : Form
        {
        public Form1()
        {
            InitializeComponent();
        }
        private void btnGenerateCode_Click(object sender, EventArgs e)
        {
            string conStrJobsDB = ConfigurationSettings.AppSettings["jobsDBConStrKey"].ToString();
            CreateEntitiesFromDBTables(GetDataReader(conStrJobsDB));
        }
        private void CreateEntitiesFromDBTables(SqlDataReader dr)
        {
            if (dr != null)
            {
                string lstrOldTableName = string.Empty;
                StreamWriter swClassWriter = null;
                System.Text.StringBuilder sbFileName = null;
                System.Text.StringBuilder sbConstructorCode = null;
                System.Text.StringBuilder sbClassCode = null;
                FileInfo tableClassFile = null;
                while (dr.Read())
                {
                    string lstrTableName = dr.GetString(0);
                    string lstrAttributeName = dr.GetString(1);
                    string lstrAttributeType = GetDotNetType(dr.GetString(2));
                    //If table name is changed...
                    if (lstrOldTableName != lstrTableName)
                    {
                        //and stream writer is already opened so close this class generation...
                        if (swClassWriter != null)
                        {
                            CreateClassBottom(swClassWriter);
                            swClassWriter.Close();
                        }
                        sbFileName = new System.Text.StringBuilder(lstrTableName);
                        sbFileName.Append("Entity.cs");
                        tableClassFile = new FileInfo(tbPath.Text + "\\" + sbFileName.ToString());
                        swClassWriter = tableClassFile.CreateText();
                        CreateClassTop(swClassWriter, lstrTableName);
                        //sbConstructorCode = new System.Text.StringBuilder("\r\n\t/// \r\n\t" +
                        //     "/// User defined Contructor\r\n\t/// \r\n\tpublic ");
                        //sbConstructorCode = new System.Text.StringBuilder();
                        //sbConstructorCode.Append(lstrTableName);
                        //sbConstructorCode.Append("(");
                    }
                    else
                    {
                        this.CreateClassBody(swClassWriter, lstrAttributeType, lstrAttributeName);
                        //sbConstructorCode.AppendFormat("{0} {1}, \r\n\t\t",
                        //   new object[] { lstrAttributeType, lstrAttributeName });
                        //sbConstructorCode.AppendFormat("\r\n\t\tthis._{0} = {0};",
                        //   new object[] { lstrAttributeName });
                    }
                    lstrOldTableName = lstrTableName;
                    this.pBarMain.Increment(1);
                }
                MessageBox.Show("All classes generated.", "Done");
            }
        }
        private SqlDataReader GetDataReader(string conStrJobsDB)
        {
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(conStrJobsDB);
                if (connection == null)
                    return null;
                connection.Open();
                SqlCommand command = new System.Data.SqlClient.SqlCommand("exec spGenerateEntitiesFromTables", connection);
                SqlDataReader dr = command.ExecuteReader();
                if (dr.HasRows)
                    return dr;
                else
                    return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        private string GetDotNetType(string dbColumnType)
        {
            string returnType = string.Empty;
            if (dbColumnType.Equals("nvarchar"))
                returnType = "string";
            else if (dbColumnType.Equals("varchar"))
                returnType = "string";
            else if (dbColumnType.Equals("int"))
                returnType = "int";
            else if (dbColumnType.Equals("bit"))
                returnType = "bool";
            else if (dbColumnType.Equals("bigint"))
                returnType = "long";
            else if (dbColumnType.Equals("binary"))
                returnType = "byte[]";
            else if (dbColumnType.Equals("char"))
                returnType = "string";
            else if (dbColumnType.Equals("date"))
                returnType = "DateTime";
            else if (dbColumnType.Equals("datetime"))
                returnType = "DateTime";
            else if (dbColumnType.Equals("datetime2"))
                returnType = "DateTime";
            else if (dbColumnType.Equals("datetimeoffset"))
                returnType = "DateTimeOffset";
            else if (dbColumnType.Equals("decimal"))
                returnType = "decimal";
            else if (dbColumnType.Equals("float"))
                returnType = "float";
            else if (dbColumnType.Equals("image"))
                returnType = "byte[]";
            else if (dbColumnType.Equals("money"))
                returnType = "decimal";
            else if (dbColumnType.Equals("nchar"))
                returnType = "char";
            else if (dbColumnType.Equals("ntext"))
                returnType = "string";
            else if (dbColumnType.Equals("numeric"))
                returnType = "decimal";
            else if (dbColumnType.Equals("nvarchar"))
                returnType = "string";
            else if (dbColumnType.Equals("real"))
                returnType = "double";
            else if (dbColumnType.Equals("smalldatetime"))
                returnType = "DateTime";
            else if (dbColumnType.Equals("smallint"))
                returnType = "short";
            else if (dbColumnType.Equals("smallmoney"))
                returnType = "decimal";
            else if (dbColumnType.Equals("text"))
                returnType = "string";
            else if (dbColumnType.Equals("time"))
                returnType = "TimeSpan";
            else if (dbColumnType.Equals("timestamp"))
                returnType = "DateTime";
            else if (dbColumnType.Equals("tinyint"))
                returnType = "byte";
            else if (dbColumnType.Equals("uniqueidentifier"))
                returnType = "Guid";
            else if (dbColumnType.Equals("varbinary"))
                returnType = "byte[]";
            return returnType;
        }
        private void CreateClassTop(StreamWriter sw, string lstrTableName)
        {
            System.Text.StringBuilder sb = null;
            sb = new StringBuilder("public class " + lstrTableName +"Entity\n{");
            sw.Write(sb.ToString());
        }
        private void CreateClassBody(StreamWriter sw, string lstrAttributeType, string lstrAttributeName)
        {
            System.Text.StringBuilder sb = null;
            sb = new StringBuilder("\n\rpublic " + lstrAttributeType + " " + lstrAttributeName + " { get; set; }");
            sw.Write(sb.ToString());
        }
        private void CreateClassBottom(StreamWriter sw)
        {
            System.Text.StringBuilder sb = null;
            sb = new StringBuilder("\n\n}");
            sw.Write(sb.ToString());
        }
      
    }
}
