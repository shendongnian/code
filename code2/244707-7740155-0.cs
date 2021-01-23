    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using CrystalDecisions.CrystalReports.Engine;
    using CrystalDecisions.Shared;
    namespace ReportExportDemo 
    { 
        class Reports 
    { 
        static TableLogOnInfo crTableLogonInfo; 
        static ConnectionInfo crConnectionInfo; 
        static Tables crTables; 
        static Database crDatabase; 
        public static void ReportLogin(ReportDocument crDoc, string Server, string Database, string UserID, string Password) 
        { 
            crConnectionInfo = new ConnectionInfo();
            crConnectionInfo.ServerName = Server;
            crConnectionInfo.DatabaseName = Database;
            crConnectionInfo.UserID = UserID;
            crConnectionInfo.Password = Password;
            crDatabase = crDoc.Database; crTables = crDatabase.Tables;
            foreach (CrystalDecisions.CrystalReports.Engine.Table crTable in crTables)
            { 
                crTableLogonInfo = crTable.LogOnInfo;
                crTableLogonInfo.ConnectionInfo = crConnectionInfo;
                crTable.ApplyLogOnInfo(crTableLogonInfo);
            }
        } 
        
        public static void ReportLogin(ReportDocument crDoc, string Server, string Database)
        {
            crConnectionInfo = new ConnectionInfo();
            crConnectionInfo.ServerName = Server;
            crConnectionInfo.DatabaseName = Database;
            crConnectionInfo.IntegratedSecurity = true;
            crDatabase = crDoc.Database; crTables = crDatabase.Tables;
            foreach (CrystalDecisions.CrystalReports.Engine.Table crTable in crTables)
            { 
                crTableLogonInfo = crTable.LogOnInfo;
                crTableLogonInfo.ConnectionInfo = crConnectionInfo;
                crTable.ApplyLogOnInfo(crTableLogonInfo);
            }
        }
    }
    }
