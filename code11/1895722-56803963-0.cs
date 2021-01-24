//------- MergeUserData--------------//
wID           username      fname         lastname      email         empid         lastlogintime UserID        Alias         UserType      AccountStatus ChgPasswdNxtLogin
msmith        marysmith     mary          smith         marysmith@company.com10001         24/01/2019 14:00msmith        mary smith    Manager       No            No            
jbloggs       joebloggs     joe           bloggs        joebloggs@company.com10002         10/01/2019 9:00jbloggs       joe bloggs    Standard      No            No            
pgolightly    petergolightlypeter         golightly     petergolightly@company.com10003         20/01/2019 17:00pgolightly    peter golightlyJunior        No            No            
rrabbit       rogerrabbit   roger         rabbit        rogerrabbit@company.com10004         1/02/2019 14:00rrabbit       roger rabbit  Standard      No            No  
2) the final ```CreateTableReport()``` looks like this (UAT tested passed):
 public void CreateTableReport()
        {
            DataColumn[] colsMerge ={
                      new DataColumn("wID",typeof(String)),      //--- Below foreach from table: sales
                      new DataColumn("username",typeof(String)), //--- Below foreach from table: wifi
                      new DataColumn("fname",typeof(String)),    //--- Below foreach from table: wifi
                      new DataColumn("lastname",typeof(String)), //--- Below foreach from table: wifi
                      new DataColumn("email",typeof(String)),    //--- Below foreach from table: wifi
                      new DataColumn("empid",typeof(String)),    //--- Below foreach from table: wifi
                      new DataColumn("lastlogintime",typeof(String)), //--- Below foreach from table: wifi
                      new DataColumn("UserID",typeof(String)),   //--- Below foreach from table: sales
                      new DataColumn("Alias",typeof(String)),    //--- Below foreach from table: sales
                      new DataColumn("UserType",typeof(String)), //--- Below foreach from table: sales
                      new DataColumn("AccountStatus",typeof(String)), //--- Below foreach from table: sales
                      new DataColumn("ChgPasswdNxtLogin",typeof(String)), //--- Below foreach from table: sales
                  };
            Table_MergeUserData.Columns.AddRange(colsMerge);
            var mergedData = (from s in Table_SalesUserData.AsEnumerable()
                              join w in Table_WifiUserData.AsEnumerable() on s.Field<string>("UserID") equals w.Field<string>("wID")
                              select new { sales = s, wifi = w }).ToList();
            foreach (var data in mergedData)
            {
                Table_MergeUserData.Rows.Add(new object[] {
                    data.sales.Field<string>("UserID"),
                    data.wifi.Field<string>("username"),
                    data.wifi.Field<string>("fname"),
                    data.wifi.Field<string>("lastname"),
                    data.wifi.Field<string>("email"),
                    data.wifi.Field<string>("empid"),
                    data.wifi.Field<string>("lastlogintime"),
                    data.sales.Field<string>("UserID"),
                    data.sales.Field<string>("Alias"),
                    data.sales.Field<string>("UserType"),
                    data.sales.Field<string>("AccountStatus"),
                    data.sales.Field<string>("ChgPasswdNxtLogin")
                });
                 
            }
3) And now for the whole enchelade, or however that is spelled. 
The whole Form1.csv, using all the same CSV files originally added, and......the CSV Parser code to import both CSV files in the first place. Hope it helps someone else in the future. This was all done in Visual Studio 2019 Community, with all the libraries etc in the "using" section. The "Form1" is a basic form, with one button "Show Table". I got the basic jist of this from the great/simple tutorial from msdn: https://docs.microsoft.com/en-us/visualstudio/ide/tutorial-1-create-a-picture-viewer?view=vs-2019 . If you are *new* to Visual Studio like i am, this is really great. In 1x week I have learnt how to do that tutorial, then regress my linux and Powershell scripts to do LDAP searches, merge data, import XLS workbooks, export to CSV, re-import CSV files and now with help from the Stack overflow community (jdwen) join dataTables and create something useful. Happiness has no bounds ! :))) 
Ok enough from me here it all is:
//========================================//
//--- Useful Pages to check out ----------//
//========================================//
//--- https://immortalcoder.blogspot.com/2013/12/convert-csv-file-to-datatable-in-c.html
//--- https://code.msdn.microsoft.com/How-to-create-DataTable-7abb4914
//--- https://www.codeproject.com/Articles/9258/A-Fast-CSV-Reader
//--- https://www.dotnetperls.com/datatable
//--- https://docs.microsoft.com/en-us/dotnet/api/system.data.datatable?view=netframework-4.8#examples
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
using System.Text.RegularExpressions;
using GenericParsing;
namespace GenericParserv1._1._6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DataTable Table_SalesUserData = new DataTable("SalesUserData");
        DataTable Table_WifiUserData = new DataTable("WifiUserData");
        DataTable Table_MergeUserData = new DataTable("MergeUserData");
        DataSet   setSalesWifi = new DataSet();
        private static void ShowTable(DataTable table)
        {
            Console.WriteLine("//------- " + table + "--------------//");
            foreach (DataColumn col in table.Columns)
            {
                Console.Write("{0,-14}", col.ColumnName);
            }
            Console.WriteLine();
            foreach (DataRow row in table.Rows)
            {
                foreach (DataColumn col in table.Columns)
                {
                    if (col.DataType.Equals(typeof(DateTime)))
                        Console.Write("{0,-14:d}", row[col]);
                    else if (col.DataType.Equals(typeof(Decimal)))
                        Console.Write("{0,-14:C}", row[col]);
                    else
                        Console.Write("{0,-14}", row[col]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        public void CreateTableSales()
        {
            DataColumn[] colsSales ={
                      new DataColumn("UserID",typeof(String)),
                      new DataColumn("Alias",typeof(String)),
                      new DataColumn("UserType",typeof(String)),
                      new DataColumn("AccountStatus",typeof(String)),
                      new DataColumn("ChgPasswdNxtLogin",typeof(String)),
                  };
            Table_SalesUserData.Columns.AddRange(colsSales);
            Table_SalesUserData.PrimaryKey = new DataColumn[] { Table_SalesUserData.Columns["UserID"] };
            setSalesWifi.Tables.Add(Table_SalesUserData);
            
        }
        public void InsertTableSales(string srcFilePathSales)
        {
            string Sales_UserID,
            Sales_Alias,
            Sales_UserType,
            Sales_AccountStatus,
            Sales_ChgPasswdNxtLogin
            ;
            using (GenericParser parser = new GenericParser())
            {
                parser.SetDataSource(srcFilePathSales);
                parser.ColumnDelimiter = ','; //---- For TAB DELIM USE: parser.ColumnDelimiter = "\t".ToCharArray();
                parser.FirstRowHasHeader = true;
                parser.SkipStartingDataRows = 0;
                parser.MaxBufferSize = 4096;
                parser.MaxRows = 500;
                parser.TextQualifier = null;
                while (parser.Read())
                {
                    Sales_UserID = parser["UserID"];
                    Sales_Alias = parser["Alias"];
                    Sales_UserType = parser["UserType"];
                    Sales_AccountStatus = parser["AccountStatus"];
                    Sales_ChgPasswdNxtLogin = parser["ChgPasswdNxtLogin"];
                    Object[] rows = {
                        new Object[]{
                                    Sales_UserID
                                    ,Sales_Alias
                                    ,Sales_UserType
                                    ,Sales_AccountStatus
                                    ,Sales_ChgPasswdNxtLogin
                        }
                     };
                    foreach (Object[] row in rows)
                    {
                        Table_SalesUserData.Rows.Add(row);
                    }
                }
            }
        }
        public void CreateTableWifi()
        {
            DataColumn[] colsWifi ={
                      new DataColumn("wID",typeof(String)),
                      new DataColumn("username",typeof(String)),
                      new DataColumn("fname",typeof(String)),
                      new DataColumn("lastname",typeof(String)),
                      new DataColumn("email",typeof(String)),
                      new DataColumn("empid",typeof(String)),
                      new DataColumn("lastlogintime",typeof(String))
                  };
            Table_WifiUserData.Columns.AddRange(colsWifi);
            Table_WifiUserData.PrimaryKey = new DataColumn[] { Table_WifiUserData.Columns["wID"] };
            setSalesWifi.Tables.Add(Table_WifiUserData);
        }
        public void InsertTableWifi(string srcFilePathWifi)
        {
            string Wifi_wID, Wifi_username, Wifi_fname, Wifi_lastname, Wifi_email, Wifi_empid, Wifi_lastlogintime;
            using (GenericParser parser = new GenericParser())
            {
                parser.SetDataSource(srcFilePathWifi);
                parser.ColumnDelimiter = ','; //---- For TAB DELIM USE: parser.ColumnDelimiter = "\t".ToCharArray();
                parser.FirstRowHasHeader = true;
                parser.SkipStartingDataRows = 0;
                parser.MaxBufferSize = 4096;
                parser.MaxRows = 500;
                parser.TextQualifier = null;
                while (parser.Read())
                {
                    Wifi_wID = parser["wID"];
                    Wifi_username = parser["username"];
                    Wifi_fname = parser["fname"];
                    Wifi_lastname = parser["lastname"];
                    Wifi_email = parser["email"];
                    Wifi_empid = parser["empid"];
                    Wifi_lastlogintime = parser["lastlogintime"];
                    Object[] rows = {
                        new Object[]{
                                    Wifi_wID
                                    ,Wifi_username
                                    ,Wifi_fname
                                    ,Wifi_lastname
                                    ,Wifi_email
                                    ,Wifi_empid
                                    ,Wifi_lastlogintime
                        }
                     };
                    foreach (Object[] row in rows)
                    {
                        Table_WifiUserData.Rows.Add(row);
                    }
                }
            }
        }
         public void CreateTableReport()
        {
            DataColumn[] colsMerge ={
                      new DataColumn("wID",typeof(String)),      //--- Below foreach from table: sales
                      new DataColumn("username",typeof(String)), //--- Below foreach from table: wifi
                      new DataColumn("fname",typeof(String)),    //--- Below foreach from table: wifi
                      new DataColumn("lastname",typeof(String)), //--- Below foreach from table: wifi
                      new DataColumn("email",typeof(String)),    //--- Below foreach from table: wifi
                      new DataColumn("empid",typeof(String)),    //--- Below foreach from table: wifi
                      new DataColumn("lastlogintime",typeof(String)), //--- Below foreach from table: wifi
                      new DataColumn("UserID",typeof(String)),   //--- Below foreach from table: sales
                      new DataColumn("Alias",typeof(String)),    //--- Below foreach from table: sales
                      new DataColumn("UserType",typeof(String)), //--- Below foreach from table: sales
                      new DataColumn("AccountStatus",typeof(String)), //--- Below foreach from table: sales
                      new DataColumn("ChgPasswdNxtLogin",typeof(String)), //--- Below foreach from table: sales
                  };
            Table_MergeUserData.Columns.AddRange(colsMerge);
            var mergedData = (from s in Table_SalesUserData.AsEnumerable()
                              join w in Table_WifiUserData.AsEnumerable() on s.Field<string>("UserID") equals w.Field<string>("wID")
                              select new { sales = s, wifi = w }).ToList();
            foreach (var data in mergedData)
            {
                Table_MergeUserData.Rows.Add(new object[] {
                    data.sales.Field<string>("UserID"),
                    data.wifi.Field<string>("username"),
                    data.wifi.Field<string>("fname"),
                    data.wifi.Field<string>("lastname"),
                    data.wifi.Field<string>("email"),
                    data.wifi.Field<string>("empid"),
                    data.wifi.Field<string>("lastlogintime"),
                    data.sales.Field<string>("UserID"),
                    data.sales.Field<string>("Alias"),
                    data.sales.Field<string>("UserType"),
                    data.sales.Field<string>("AccountStatus"),
                    data.sales.Field<string>("ChgPasswdNxtLogin")
                });
                 
            }
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            string srcFilePathWifi = @"C:\WifiUserData.csv";
            string srcFilePathSales = @"C:\SalesUserData.csv";
            CreateTableSales();
            InsertTableSales(srcFilePathSales);
            CreateTableWifi();
            InsertTableWifi(srcFilePathWifi);
            ShowTable(Table_WifiUserData);
            ShowTable(Table_SalesUserData);
            CreateTableReport();
            ShowTable(Table_MergeUserData);
        }
    }
}
