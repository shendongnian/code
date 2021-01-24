    using System;
    using System.ComponentModel.Design;
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
                        this.Rows.Add(2);
                }));
                designer?.Verbs?.Add(new DesignerVerb("Clear data", (o, a) =>
                {
                    this.Rows.Clear();
                }));
            }
        }
    }
