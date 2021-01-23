        <dx:ASPxGridView ID="ASPxGridView1" runat="server" OnCustomSummaryCalculate="ASPxGridView1_CustomSummaryCalculate">
            <TotalSummary>
                <dx:ASPxSummaryItem FieldName="Price" SummaryType="Custom" ShowInColumn="Price" />
            </TotalSummary>
            <Settings ShowFooter="True" />
        </dx:ASPxGridView>
...
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Collections;
    
        protected void Page_Init(object sender, EventArgs e) {
            ASPxGridView1.DataSource = GetDataSource();
            ASPxGridView1.DataBind();
        }
    
        private object CreateDataSource() {
            DataTable table = new DataTable();
            table.Columns.Add("Customer_No", typeof(int));
            table.Columns.Add("Price", typeof(int));
            table.Rows.Add(new object[] {123, 50 });
            table.Rows.Add(new object[] {123, 100 });
            table.Rows.Add(new object[] {123, 60 });
            table.Rows.Add(new object[] {124, 60 }); 
            table.Rows.Add(new object[] {125, 20 });
            table.Rows.Add(new object[] {125, 40 });
            return table;
        }
        private object GetDataSource() {
            if(Session["data"] == null)
                Session["data"] = CreateDataSource();
            return Session["data"];
        }
    
        Dictionary<int, List<int>> dict;
        protected void ASPxGridView1_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e) {
            if(e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Start)
                dict = new Dictionary<int, List<int>>();
            if(e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Calculate) {
                int customer_No = Convert.ToInt32(e.GetValue("Customer_No"));
                List<int> list;
                if(!dict.TryGetValue(customer_No, out list)) {
                    list = new List<int>();
                    dict.Add(customer_No, list);
                }
                list.Add(Convert.ToInt32(e.GetValue("Price")));
            }
            if(e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Finalize) {
                e.TotalValue = CalculateTotal();
            }
        }
        private object CalculateTotal() {
            IEnumerator en = dict.GetEnumerator();
            en.Reset();
            float result = 0;
            while(en.MoveNext()) {
                KeyValuePair<int, List<int>> current = ((KeyValuePair<int, List<int>>)en.Current);
                int sum = 0;
                for(int i = 0; i < current.Value.Count; i++)
                    sum += current.Value[i];
                result += sum / current.Value.Count;
            }
            return result;
        }
