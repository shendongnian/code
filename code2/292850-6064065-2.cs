    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Runtime.InteropServices;
    using System.Security;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1() {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e) {
                var dt = new DataTable();
                dt.Columns.Add("Col1");
                dt.Columns.Add("Col2");
                dt.Rows.Add(new object[] { "row 1", "20" });
                dt.Rows.Add(new object[] { "row 2", "2" });
                dt.Rows.Add(new object[] { "row 3", "10" });
                dt.Rows.Add(new object[] { "row 4", "1" });
                
                var ds = new DataSet();
                ds.Tables.Add(dt);
    
                var query = ds.Tables[0].AsEnumerable().OrderBy(r => r.Field<string>("Col2"), new NaturalStringComparer());
    
                dataGridView1.DataSource = query.AsDataView();
            }
    
            //
            // Comparer for natural sort.
            //   https://stackoverflow.com/questions/248603/natural-sort-order-in-c
            //   ** see answers for warnings on this implementation **
            //
            [DllImport("shlwapi.dll", CharSet = CharSet.Unicode)]
            private static extern int StrCmpLogicalW(string psz1, string psz2);
    
            [SuppressUnmanagedCodeSecurity]
            internal static class SafeNativeMethods
            {
                [DllImport("shlwapi.dll", CharSet = CharSet.Unicode)]
                public static extern int StrCmpLogicalW(string psz1, string psz2);
            }
    
            public sealed class NaturalStringComparer : IComparer<string>
            {
                public int Compare(string a, string b) {
                    return SafeNativeMethods.StrCmpLogicalW(a, b);
                }
            }
        }
    }
