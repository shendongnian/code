    using Swfd = System.Windows.Forms.Design;
    using Scm = System.ComponentModel; 
    using Sdd = System.Drawing.Design;
    public class CustomCollectionModalEditor : Sdd.UITypeEditor
    {
	public override Sdd.UITypeEditorEditStyle GetEditStyle(Scm.ITypeDescriptorContext context)
	{
	    if (context == null || context.Instance == null)
		return base.GetEditStyle(context);
	    return Sdd.UITypeEditorEditStyle.Modal;
	}
	public override object EditValue(Scm.ITypeDescriptorContext context, IServiceProvider provider, object value)
	{
	    Swfd.IWindowsFormsEditorService editorService;
	    if (context == null || context.Instance == null || provider == null)
		return value;
	    editorService = (Swfd.IWindowsFormsEditorService)provider.GetService(typeof(Swfd.IWindowsFormsEditorService));
	    //CForm CollectionEditor = new CForm();
	    //---  Replaced the Collection from this post with mine which requires an argument that passes the collection
	    Ccne.CustomCollection editgcp = new Ccne.CustomCollection();  // Ccne.CustomCollection is my collection
	    editgcp = MYGCPS;  // MYGCPS is the actual instance to be edited
	    Gcp_Editor.GcpEditorMain CollectionEditor = new Gcp_Editor.GcpEditorMain(editgcp);  // call my editor 
	    if (editorService.ShowDialog(CollectionEditor) == System.Windows.Forms.DialogResult.OK)
	    {
		MYGCPS = CollectionEditor.ReturnValue1; // update current instance of the collection with the returned edited collection
		THISPG.Refresh();  // calls a method which refreshes the property grid
		return value; // the replaces the statment in the post >> CollectionEditor.Programmed;
	    }
	    //---
	    return value;
	    //return base.EditValue(context, provider, value);
	}
    }
    //---------- The propertygrid entry
    private Ccne.CustomCollection gCPs; 
    [Scm.Category("3 - Optional inputs to run gdal_translate")]
    [PropertyOrder(133)]
    [Scm.TypeConverter(typeof(Ccne.CustomCollectionConverter))]
    [Scm.Editor(typeof(CustomCollectionModalEditor), typeof(Sdd.UITypeEditor))]
    [Scm.Description("The Collection of the single or multiple Ground Control Points (Gcp)" +
	" entered. \n Each gcp requires a Name, pixel, line, easting, " +
	"northing, and optionally an elevation")]
    [Scm.RefreshProperties(Scm.RefreshProperties.All)] // http://stackoverflow.com/questions/3120496/updating-a-propertygrid
    [Scm.DisplayName("23 Collection of Gcp's")]
    [Scm.ReadOnly(true)]                   // prevents values being changed without validation provided by form
    public Ccne.CustomCollection GCPs
    {
	get { return gCPs; }
	set { gCPs = value; }
    }
    
    //-------- important code from CollectionEditor i.e. > Gcp_Editor.GcpEditorMain(editgcp)
    using Swf = System.Windows.Forms;
    namespace Gcp_Editor
    {
        public partial class GcpEditorMain : Swf.Form
        {
            public Ccne.CustomCollection ReturnValue1 { get; set; }
            ...
            public GcpEditorMain(Ccne.CustomCollection input1)
	        {
	                InitializeComponent();
	                formcollection = input1;
            }
            ...
            private void OkayBtn_Click(object sender, EventArgs e)
            {
                this.DialogResult = Swf.DialogResult.OK;
                ReturnValue1 = formcollection;
                return;
            }   
