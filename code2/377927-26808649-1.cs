    //References
    // https://social.msdn.microsoft.com/Forums/vstudio/en-US/0e0da0c9-299e-46d0-b8b0-4ccdda15894c/how-to-assign-values-to-checkedlistbox-items-and-sum-these-values?forum=csharpgeneral
    using Microsoft.Practices.EnterpriseLibrary.Data;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Windows.Forms;
    namespace MyApp
    {
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DatabaseProviderFactory factory = new DatabaseProviderFactory(); 
            Database db = factory.Create("MyConnString");
            DataTable dt = db.ExecuteDataSet(CommandType.StoredProcedure, "ProcGetCustomers").Tables[0];
            var custlist = new List<CheckBoxItem<string, string>>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                custlist.Add(Create(dt.Rows[i]["DESC"].ToString(), dt.Rows[i]["CODE"].ToString()));
            }
            checkedListBox1.Items.AddRange(custlist.Cast<object>().ToArray());
       }
        public class CheckBoxItem<K, V>
        {
            public CheckBoxItem(K displayValue, V hiddenValue)
            {
                DisplayValue = displayValue;
                HiddenValue = hiddenValue;
            }
            public K DisplayValue { get; private set; }
            public V HiddenValue { get; private set; }
            public override string ToString()
            {
                return DisplayValue == null ? "" : DisplayValue.ToString();
            }
        }
        public static CheckBoxItem<K, V> Create<K, V>(K displayValue, V hiddenValue)
        {
            return new CheckBoxItem<K, V>(displayValue, hiddenValue);
        }
      }
    }
