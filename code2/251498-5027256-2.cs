    public class MWCropperPrevalueEditor : System.Web.UI.WebControls.PlaceHolder, umbraco.interfaces.IDataPrevalue
        {
            #region IDataPrevalue Members
    
            // referenced datatype
            private umbraco.cms.businesslogic.datatype.BaseDataType _datatype;
    
          
            private TextBox _txtWidth;
            private TextBox _txtHeight;
            public MWCropperPrevalueEditor(umbraco.cms.businesslogic.datatype.BaseDataType DataType)
            {
    
                _datatype = DataType;
                setupChildControls();
    
            }
    
            private void setupChildControls()
            {
                
                _txtWidth = new TextBox();
                _txtWidth.ID = "txtWidth";
                _txtWidth.CssClass = "umbEditorTextField";
                Controls.Add(_txtWidth);
                _txtHeight = new TextBox();
                _txtHeight.ID = "txtHeight";
                _txtHeight.CssClass = "umbEditorTextField";
                Controls.Add(_txtHeight);
              
    
            }
    
    
    
            public Control Editor
            {
                get
                {
                    return this;
                }
            }
    
    
            protected override void OnLoad(EventArgs e)
            {
                base.OnLoad(e);
                if (!Page.IsPostBack)
                {
                    
                    if (Configuration.Length > 0)
                    {
                        string[] value = Configuration.Split(new char[]{';'});
                        _txtWidth.Text = value[0];
                        _txtHeight.Text = value[1];
    
                    }
                    else
                    {
                        _txtHeight.Text = "100";
                        _txtWidth.Text = "100";
                    }
    
    
                }
    
    
            }
    
            public void Save()
            {
                _datatype.DBType = (umbraco.cms.businesslogic.datatype.DBTypes)Enum.Parse(typeof(umbraco.cms.businesslogic.datatype.DBTypes), DBTypes.Ntext.ToString(), true);
    
    
                string data = _txtWidth.Text+";"+_txtHeight.Text;
    
                SqlHelper.ExecuteNonQuery("delete from cmsDataTypePreValues where datatypenodeid = @dtdefid", 
                        SqlHelper.CreateParameter("@dtdefid", _datatype.DataTypeDefinitionId));
                SqlHelper.ExecuteNonQuery("insert into cmsDataTypePreValues (datatypenodeid,[value],sortorder,alias) values (@dtdefid,@value,0,'')", 
                        SqlHelper.CreateParameter("@dtdefid", _datatype.DataTypeDefinitionId), SqlHelper.CreateParameter("@value", data));
    
            }
    
            protected override void Render(HtmlTextWriter writer)
            {
                writer.WriteLine("<table>");
                writer.Write("<tr><th>Width:</th><td>");
                _txtWidth.RenderControl(writer);
                writer.Write("</td></tr>");
                writer.Write("<tr><th>Height:</th><td>");
                _txtHeight.RenderControl(writer);
                writer.Write("</td></tr>");
                writer.Write("</table>");
            }
    
            public string Configuration
            {
                get
                {
                    object conf =
                       SqlHelper.ExecuteScalar<object>("select value from cmsDataTypePreValues where datatypenodeid = @datatypenodeid",
                                               SqlHelper.CreateParameter("@datatypenodeid", _datatype.DataTypeDefinitionId));
    
                    if (conf != null)
                        return conf.ToString();
                    else
                        return "";
    
                }
            }
    
            #endregion
    
            public static ISqlHelper SqlHelper
            {
                get
                {
                    return Application.SqlHelper;
                }
            }
        }
