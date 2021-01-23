    /// tried this attribute - did not work
    /// [Designer(typeof (System.Windows.Forms.Design.ControlDesigner))]
    /// this did not work either
    [Editor("System.Windows.Forms.Design.DataGridViewComponentEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(ComponentEditor))]
    [Designer("System.Windows.Forms.Design.DataGridViewDesigner, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
    public class ucInheritedDataGridView : DataGridView { }
