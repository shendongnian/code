        private static CodeSnippetTypeMember CreateStaticClass(CodeTypeDeclaration type)
        {
            var provider = CodeDomProvider.CreateProvider("CSharp");
            using (var sourceWriter = new StringWriter())
            using (var tabbedWriter = new IndentedTextWriter(sourceWriter, "\t"))
            {
                tabbedWriter.Indent = 2;
                provider.GenerateCodeFromType(type, tabbedWriter, new CodeGeneratorOptions()
                {
                    BracingStyle = "C",
                    IndentString = "\t"
                });
                return new CodeSnippetTypeMember("\t\t" + sourceWriter.ToString().Replace("public class", "public static class"));
            }
        }
