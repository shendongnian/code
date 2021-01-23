    using System.CodeDom;
    using Microsoft.CSharp;
    //...
    Type targetType = typeof(IList<string>);
    //...
    CSharpCodeProvider provider = new CSharpCodeProvider();
    CodeExpression cast = new CodeCastExpression(targetType, new CodeVariableReferenceExpression("genericCollection"));
    CodeStatement statement = new CodeVariableDeclarationStatement(new CodeTypeReference(targetType), "list", cast);
    using(StringWriter writer = new StringWriter()) {
        provider.GenerateCodeFromStatement(statement, writer, null);
        string expression = writer.ToString();
       // expression is "System.Collections.Generic.IList<string> list = ((System.Collections.Generic.IList<string>)(genericCollection));"
    }
