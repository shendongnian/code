    using System;
    using System.Data;
    using System.Linq;
    using System.Windows.Forms;
    namespace WindowsFormsApplication1
    {
        public partial class Form2 : Form
        {
            /// <summary>
            /// You can optimize this functionality only when the first column is sorted. 
            /// If not there is no faster way other than linear search, even if it would be done by framework, in my opinion linear search is the best posssible solution when the first column is not sorted.
            /// This piece of code is for demo purposes on how to do something, should be refined to fit your production cases.
            /// </summary>
            private void textBox1_TextChanged(object sender, EventArgs e)
            {
                string text = textBox1.Text.Trim();
                int index = dataGridView1.CurrentCell.RowIndex;
                CurrencyManager cm = dataGridView1.BindingContext[dataGridView1.DataSource] as CurrencyManager;
                DataView view = cm.List as DataView;
                if (string.IsNullOrEmpty(text)) return;
                //If sorted on first column
                if (view.Sort.Contains("First")) //column will be "[First]"
                {
                    index = source.DefaultView.Find(text);
                    SetIndex(cm, index);
                }
                //if not
                else if (view.Sort.Contains("Second")) //column will be "[Second]"
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        if (dataGridView1.Rows[i].Cells["First"].Value.ToString().StartsWith(text))
                        {
                            index = i; break;
                        }
                    }
                    SetIndex(cm, index);
                }
            }
            private void SetIndex(CurrencyManager cm, int index)
            {
                if (index >= 0 && index < source.Rows.Count)
                {
                    cm.Position = index;
                }
            }
            private void CreateData()
            {
                source.Columns.Add("First", typeof(string));
                source.Columns.Add("Second", typeof(string));
                var f = from first in Enumerable.Range('a', 26)
                        select new string(new char[] { (char)first });
                var s = from second in Enumerable.Range('a', 26)
                        select new string(new char[] { (char)second });
                s = s.Reverse();
                var firstEnumerator = f.GetEnumerator();
                var secondEnumerator = s.GetEnumerator();
                for (int i = 0; i < f.Count(); i++)
                {
                    firstEnumerator.MoveNext();
                    secondEnumerator.MoveNext();
                    DataRow dr = source.NewRow();
                    dr[0] = firstEnumerator.Current;
                    dr[1] = secondEnumerator.Current;
                    source.Rows.Add(dr);
                }
            }
            DataTable source = new DataTable();
            public Form2()
            {
                InitializeComponent();
            }
            private void Form2_Load(object sender, EventArgs e)
            {
                CreateData();
                dataGridView1.DataSource = source;
            }
        }
    }
