t4
<#@ template hostspecific="false" language="C#" #>
<#@ output extension=".cs" #>
<#
string currentYear = DateTime.Now.Year.ToString();
#>
using System;
using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;
// [... snip ...]
[assembly: AssemblyTrademark("Something from year <#= currentYear #>")]
might work for you?
