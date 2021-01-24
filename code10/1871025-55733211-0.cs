    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication108
    {
        class Program
        {
            static void Main(string[] args)
            {
                DataBase db = new DataBase();
                int ProcessStatus = 1;
                int ProcessID = 21;
                int Status = 1;
                DateTime today = DateTime.Now.Date;
                string BankAccountID = "ABC";
                int AdjustmentMethod = 5;
                var results = (from A in db.Approved
                                   .Where(x => (x.ProcessID == ProcessID) 
                                       && (x.Status == Status) 
                                       && (x.EffectiveStartDate >= today) 
                                       && (today < x.EffectiveEndDate))
                              join OA in db.OrgApproval
                                   .Where(x => (x.ProcessID == ProcessID) 
                                       && (x.EffectiveStartDate >= today) 
                                       && (today < x.EffectiveEndDate) 
                                       && (x.BankAccountID == BankAccountID) 
                                       && (x.ValidatedFlag == DBNull.Value)
                                       && (x.ProcessStatus == ProcessStatus)
                                       && (x.AdjustmentMethod == AdjustmentMethod)) on A.OrgApprovalID equals OA.OrgApprovalID
                              select new { A = A, OA = OA })
                              .Where(x => (x.OA.ApprovalLevel < db.OrgApproval.Where(y => x.OA.OrgStructureID == y.OrgStructureID).Max(z => z.ApprovalLevel)) && (x.A.ApprovalLevel == x.OA.ApprovalLevel))
                              .GroupBy(x => x.OA.OrgStructureID)
                              .SelectMany(x =>  x.Select(y => new { RecordIDKey = y.A.RecordIDKey, ApprovalLevel = y.A.ApprovalLevel}))
                              .ToList();
            }
        }
        public class DataBase
        {
            public List<Approved> Approved { get; set; }
            public List<OrgApproval> OrgApproval { get; set; } 
        }
        public class Approved
        {
            public string OrgApprovalID { get; set; }
            public int ProcessID { get; set; }
            public int Status { get; set; }
            public DateTime EffectiveStartDate { get; set; }
            public DateTime EffectiveEndDate { get; set; }
            public string RecordIDKey { get; set; }
            public int ApprovalLevel { get; set; }
        }
        public class OrgApproval
        {
            public int ProcessID { get; set; }
            public string OrgApprovalID { get; set; }
            public string  OrgStructureID { get; set; }
            public int ApprovalLevel { get; set; }
            public string NumberofApprovalRequired { get; set; }
            public string BankAccountID { get; set; }
            public object ValidatedFlag { get; set; }
            public int ProcessStatus { get; set; }
            public int AdjustmentMethod { get; set; }
            public int CurrentLevel { get; set; }
     
            public DateTime EffectiveStartDate { get; set; }
            public DateTime EffectiveEndDate { get; set; }
        }
      
    }
