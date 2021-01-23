    <#@ template debug="false" hostspecific="true" language="C#v3.5" #>
    <#@ assembly name="System.Core.dll" #>
    <#@ assembly name="System.Data.dll" #>
    <#@ import namespace="System.Collections.Generic" #>
    <#@ import namespace="System.Linq" #>
    <#@ output extension=".cs" #>
    <#
            List<string> DataList = AccessInMemoryData();
    #>
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    namespace TestProject1
    {
    [TestClass]
    public class UnitTest1
    {
        <# foreach (string currentTestString in DataList) { #>
        [TestMethod]
        public void TestingString_<#= currentTestString #>
        {
        string currentTestString = "<#= currentTestString #>";
        // TODO: Put your standard test code here which will use the string you created above
        }
        <# } #>
    }
    }
