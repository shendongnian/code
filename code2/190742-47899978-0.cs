        using ICSharpCode.NRefactory.CSharp;
        using System;
        using System.Collections.Generic;
        using System.IO;
        using System.Linq;
        using System.Text;
        using System.Threading.Tasks;
        namespace Ns1
        {
            public class Foo
            {
        		public void Go()
        		{		
        			CSharpParser parser = new CSharpParser();
        			string text = File.ReadAllText("myProgram.cs");
        			SyntaxTree syntaxTree = parser.Parse(text);
        		}
        	}
        }
