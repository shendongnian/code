c#
<#@ template debug="false" hostspecific="false" language="C#" #>
<#@ assembly name="System.Core" #>
<#@ import namespace="System.Linq" #>
<#@ import namespace="System.Text" #>
<#@ import namespace="System.Collections.Generic" #>
<#@ output extension=".cs" #>
<# var AxisProperties = new List<(string,string,string,string)> {
	("Acceleration",		"AC",	"double",	"Acceleration Setting for Axis"), 
	("EStopDeceleration",	"AE",	"double",	"E-Stop Acceleration Setting For Axis")
}; #>
// This code is generated from NewportESP301 Property Template.tt
namespace NewportESP30xController
{
	public abstract class NewportESP301AxisProperties : ESPMotionInterfaceBase
	{
		public abstract int AxisNumber { get; }
	<# // This code runs in the text template:
	foreach ((string propertyName, string codeName, string dataType, string description) in AxisProperties)  { #>
	/// <summary>
		/// <#= description #>
		/// </summary>
        public <#= dataType #> <#= propertyName #>
        {
            get
            {
                CheckErrorStatus(_controllerDevice.<#= codeName #>_Get(AxisNumber, out <#= dataType #> value, out string errorString), errorString);
                return value;
            }
            set
            {
                // TODO: Validate Value?
                CheckErrorStatus(_controllerDevice.<#= codeName #>_Set(AxisNumber, value, out string errorString), errorString);
            }
        }
	<# } #>
}
}
and here's the C# that it generates: 
c#
// This code is generated from NewportESP301 Property Template.tt
namespace NewportESP30xController
{
	public abstract class NewportESP301AxisProperties : ESPMotionInterfaceBase
	{
		public abstract int AxisNumber { get; }
		/// <summary>
		/// Acceleration Setting for Axis
		/// </summary>
        public double Acceleration
        {
            get
            {
                CheckErrorStatus(_controllerDevice.AC_Get(AxisNumber, out double value, out string errorString), errorString);
                return value;
            }
            set
            {
                // TODO: Validate Value?
                CheckErrorStatus(_controllerDevice.AC_Set(AxisNumber, value, out string errorString), errorString);
            }
        }
		/// <summary>
		/// E-Stop Acceleration Setting For Axis
		/// </summary>
        public double EStopDeceleration
        {
            get
            {
                CheckErrorStatus(_controllerDevice.AE_Get(AxisNumber, out double value, out string errorString), errorString);
                return value;
            }
            set
            {
                // TODO: Validate Value?
                CheckErrorStatus(_controllerDevice.AE_Set(AxisNumber, value, out string errorString), errorString);
            }
        }
    }
}
  [1]: https://docs.microsoft.com/en-us/visualstudio/modeling/design-time-code-generation-by-using-t4-text-templates?view=vs-2017#generating-code-or-resources-for-your-solution
