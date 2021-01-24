        private void btnUpdateCustomDocProp_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            Excel.Application xlApp = (Excel.Application)System.Runtime.InteropServices.Marshal.GetActiveObject("Excel.application");
            Excel.Workbook wb = xlApp.ActiveWorkbook;
            object docProps = wb.BuiltinDocumentProperties;
            object prop = ExistsDocProp("Author", docProps);
            if (prop!=null)
            {
                object oProp = prop;
                Type oPropType = oProp.GetType();
                //read current value
                string propValue = oPropType.InvokeMember("Value",
                    BindingFlags.GetProperty | BindingFlags.Default,
                    null, oProp, new object[] { }).ToString();
                object oPropValue = "new test author";
                //write new value
                oPropType.InvokeMember("Value",
                    BindingFlags.SetProperty | BindingFlags.Default,
                    null, oProp, new object[] {oPropValue});
                MessageBox.Show(propValue + ", " + oPropValue.ToString());         
            }
        }
        private object ExistsDocProp(string propName, object props)
        {
            Office.DocumentProperty customDocProp = null;
            Type docPropsType = props.GetType();
            object nrProps;
            object itemProp = null;
            object oPropName;
            nrProps = docPropsType.InvokeMember("Count",
                BindingFlags.GetProperty | BindingFlags.Default,
                null, props, new object[] { });
            int iProps = (int)nrProps;
            for (int counter = 1; counter <= ((int)nrProps); counter++)
            {
                itemProp = docPropsType.InvokeMember("Item",
                    BindingFlags.GetProperty | BindingFlags.Default,
                    null, props, new object[] { counter });
                oPropName = docPropsType.InvokeMember("Name",
                    BindingFlags.GetProperty | BindingFlags.Default,
                    null, itemProp, new object[] { });
                if (propName == oPropName.ToString())
                {
                    break;
                }
            }
            return itemProp; 
        }
