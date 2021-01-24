    using System;
    using System.ComponentModel.Design;
    using System.Linq;
    using System.Windows.Forms;
    using System.Windows.Forms.Design;
    public class MyDataGridView : DataGridView
    {
        private IDesignerHost designerHost;
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            if (DesignMode && Site != null)
            {
                designerHost = Site.GetService(typeof(IDesignerHost)) as IDesignerHost;
                var designer = (ControlDesigner)designerHost?.GetDesigner(this);
                designer?.Verbs?.Add(new DesignerVerb("Preview with dummy data", (o, a) =>
                {
                    //Some logic to add dummy rows, just for example
                    this.Rows.Clear();
                    if (Columns.Count > 0)
                    {
                        var values = Columns.Cast<DataGridViewColumn>()
                            .Select(x => GetDummyData(x)).ToArray();
                        for (int i = 0; i < 2; i++)
                            Rows.Add(values);
                    }
                }));
                designer?.Verbs?.Add(new DesignerVerb("Clear data", (o, a) =>
                {
                    this.Rows.Clear();
                }));
            }
        }
        private object GetDummyData(DataGridViewColumn column)
        {
            //You can put some logic to generate dummy data based on column type, etc.
            return "Sample";
        }
    }
