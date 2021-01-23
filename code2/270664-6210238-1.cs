    /* Microsoft SQL Server Integration Services Script Component
    *  Write scripts using Microsoft Visual C# 2008.
    *  ScriptMain is the entry point class of the script.*/
    
    using System;
    using System.Data;
    using Microsoft.SqlServer.Dts.Pipeline.Wrapper;
    using Microsoft.SqlServer.Dts.Runtime.Wrapper;
    
    [Microsoft.SqlServer.Dts.Pipeline.SSISScriptComponentEntryPointAttribute]
    public class ScriptMain : UserComponent
    {
        IDTSVariables100 varCollection = null;
        string customer = string.Empty;
        int customerPosition = 0;
        int customerLength = 0;
        string vendor = string.Empty;
        int vendorPosition = 0;
        int vendorLength = 0;
    
        public override void PreExecute()
        {
            this.VariableDispenser.LockForRead("User::Customer");
            this.VariableDispenser.LockForRead("User::CustomerPosition");
            this.VariableDispenser.LockForRead("User::CustomerLength");
            this.VariableDispenser.LockForRead("User::Vendor");
            this.VariableDispenser.LockForRead("User::VendorPosition");
            this.VariableDispenser.LockForRead("User::VendorLength");
            this.VariableDispenser.GetVariables(out varCollection);
    
            customer = varCollection["User::Customer"].Value.ToString();
            customerPosition = Convert.ToInt32(varCollection["User::CustomerPosition"].Value);
            customerLength = Convert.ToInt32(varCollection["User::CustomerLength"].Value);
            vendor = varCollection["User::Vendor"].Value.ToString();
            vendorPosition = Convert.ToInt32(varCollection["User::VendorPosition"].Value);
            vendorLength = Convert.ToInt32(varCollection["User::VendorLength"].Value);
    
            base.PreExecute();
        }
    
        public override void PostExecute()
        {
            base.PostExecute();
        }
    
        public override void Input0_ProcessInputRow(Input0Buffer Row)
        {
            if (Row.Header.ToString().Trim() == customer)
            {
                Row.SNumber = Convert.ToInt32(Row.Value.Substring(customerPosition, customerLength));
            }
            else if (Row.Header.ToString().Trim() == vendor)
            {
                Row.SNumber = Convert.ToInt32(Row.Value.Substring(vendorPosition, vendorLength));
            }
            else
            {
                Row.SNumber = 0;
            }
        }
    
    }
