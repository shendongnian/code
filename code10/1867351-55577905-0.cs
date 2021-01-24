    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace ConsoleApplication108
    {
        class Program
        {
            static void Main(string[] args)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("idfptran", typeof(string));
                dt.Columns.Add("idperson", typeof(string));
                dt.Columns.Add("Patient", typeof(string));
                dt.Columns.Add("date", typeof(DateTime));
                dt.Columns.Add("idmed", typeof(int));
                dt.Columns.Add("MedicineName", typeof(string));
                dt.Columns.Add("quantity", typeof(int));
                dt.Columns.Add("Date Dispense", typeof(DateTime));
                dt.Rows.Add(new object[] {"F-1", "00001", "Jenny Jones", DateTime.Parse("4/8/19"), 1, "Cetirizine", 5, DateTime.Parse("4/8/19")});
                dt.Rows.Add(new object[] {"F-1", "00001", "Jenny Jones", DateTime.Parse("4/8/19"), 3, "Tylenol", 8, DateTime.Parse("4/8/19")});
                dt.Rows.Add(new object[] {"I-1", "00015", " Mark Sawyer", DateTime.Parse("4/8/19"), 2, "Salbutamol", 2, DateTime.Parse("4/8/19")});
                dt.Rows.Add(new object[] {"I-1", "00015", " Mark Sawyer", DateTime.Parse("4/8/19"), 4, "Amoxicillin", 3, DateTime.Parse("4/8/19")});
                dt.Rows.Add(new object[] {"I-1", "00015", " Mark Sawyer", DateTime.Parse("4/8/19"), 7, "Carbocisteine", 3, DateTime.Parse("4/8/19")});
                var groups = dt.AsEnumerable().GroupBy(x => new { idperson = x.Field<string>("idperson"), dispense = x.Field<DateTime>("Date Dispense") }).ToList();
                int maxMedicenes = groups.Select(x => x.Count()).Max(x => x);
                DataTable pivot = new DataTable();
                pivot.Columns.Add("idfptran", typeof(string));
                pivot.Columns.Add("idperson", typeof(string));
                pivot.Columns.Add("Patient", typeof(string));
                pivot.Columns.Add("date", typeof(DateTime));
                for (int i = 1; i <= maxMedicenes; i++)
                {
                    pivot.Columns.Add("idmed_" + i.ToString(), typeof(int));
                    pivot.Columns.Add("MedicineName_" + i.ToString(), typeof(string));
                    pivot.Columns.Add("quantity_" + i.ToString(), typeof(int));
                }
                pivot.Columns.Add("Date Dispense", typeof(DateTime));
                foreach (var group in groups)
                {
                    DataRow newRow = pivot.Rows.Add();
                    newRow["idfptran"] = group.First().Field<string>("idfptran");
                    newRow["idperson"] = group.Key.idperson;
                    newRow["Patient"] = group.First().Field<string>("Patient");
                    newRow["date"] = group.First().Field<DateTime>("date");
                    int i = 1;
                    foreach (DataRow row in group)
                    {
                        newRow["idmed_" + i.ToString()] = row.Field<int>("idmed");
                        newRow["MedicineName_" + i.ToString()] = row.Field<string>("MedicineName");
                        newRow["quantity_" + i.ToString()] = row.Field<int>("quantity");
                        i++;
                    }
                    newRow["Date Dispense"] = group.Key.dispense;
                }
            }
        }
    }
