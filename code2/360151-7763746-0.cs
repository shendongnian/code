	<#@ template debug="false" hostspecific="true" language="C#v3.5" #>
	<#@ assembly name="System.Core.dll" #>
	<#@ assembly name="System.Data.dll" #>
	<#@ import namespace="System.IO" #>
	<#@ import namespace="System.Collections.Generic" #>
	<#@ import namespace="System.Linq" #>
	<#@ output extension=".cs" #>
	<#
	            string inputDirectory = @"d:\temp";
	            var files = System.IO.Directory.GetFiles(inputDirectory);
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
			<# foreach (string filePath in files) { #>
	        [TestMethod]
	        public void TestingFile_<#=System.IO.Path.GetFileNameWithoutExtension(filePath).Replace(' ','_').Replace('-','_')#>()
	        {
			File currentFile = System.IO.File.Open(@"<#= filePath #>", FileMode.Open);
			// TODO: Put your standard test code here which will use the file you opened above
	        }
			<# } #>
	    }
	}
