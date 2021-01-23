    using System;
    using System.Windows.Forms;
    using DevExpress.XtraEditors.Repository;
    using DevExpress.XtraTreeList.Columns;
    using DevExpress.XtraEditors.Controls;
    using DevExpress.XtraTreeList.Data;
    public class Form1 : Form
    {
        [STAThread]
        static void Main()
        {
            Application.Run(new Form1());
        }
        
         public Form1()
        {
            this.ClientSize = new System.Drawing.Size(700, 500);
            DevExpress.XtraTreeList.TreeList treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.Controls.Add(treeList1);
            treeList1.Dock = DockStyle.Fill;
            var permissions = new System.Collections.Generic.List<TestClass>();
            permissions.Add(new TestClass() { Id = 1 , Description = "Desc1" });
            permissions.Add(new TestClass() { Id = 99, Description = "Desc2" });
                    // Your code
                    RepositoryItemLookUpEdit rep = new RepositoryItemLookUpEdit();
                    rep.TextEditStyle = TextEditStyles.DisableTextEditor;
                    //rep = new RepositoryItemComboBox();
                    //rep.Items.AddRange(new SecuredObject<QuestionnaireCategory>().PermissionType);
                    //rep.Items.AddRange(new object[] { "A", "B", "C" });
                    treeList1.RepositoryItems.Add(rep);
                    TreeListColumn disciplineColumn = treeList1.Columns.Add();
                    disciplineColumn.Caption = "Discipline";
                    disciplineColumn.Visible = true;
                    disciplineColumn.FieldName = "Entity.Description";
                    disciplineColumn.OptionsColumn.AllowEdit = false;
                    TreeListColumn permissionColumn = treeList1.Columns.Add();
                    permissionColumn.Caption = "Permissie";
                    permissionColumn.Visible = true;
                    permissionColumn.Name = "Permission";
                    //permissionColumn.FieldName = "PermissionType";
                    permissionColumn.UnboundType = UnboundColumnType.Object;
                    permissionColumn.ColumnEdit = rep;
                    //permissionColumn.OptionsColumn.ReadOnly = false;
                    //permissionColumn.OptionsColumn.AllowEdit = true;
                    rep.DataSource = permissions;
                    rep.DisplayMember = "Description";
                    rep.ValueMember = "Id";
                    rep.Name = "ola";
                    rep.ThrowExceptionOnInvalidLookUpEditValueType = true;
                    // End Your code
            bool unBoundMode = true;
            if (unBoundMode)
            {
                treeList1.AppendNode(new object[] { "Item1", 1 }, -1);
                treeList1.AppendNode(new object[] { "Item2", 99 }, -1);
            }
            else
            {
                treeList1.DataSource = permissions;
                permissionColumn.FieldName = "Id";
            }
        }
    }
    public class TestClass
    {
        public int Id             { get; set; }
        public string Description { get; set; }
    }
