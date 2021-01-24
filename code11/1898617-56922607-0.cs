    <#@ template debug="false" hostspecific="false" language="C#" #>
    <#@ output extension=".cs" #>
    
    namespace MyApp
    {
        public class Calculator
        {
        <# 
            var types = new string[] { "int", "long", "float", "double" };
    
            foreach(var T in types)
            {
        #>
            public <#=T#> Add(<#=T#> a, <#=T#> b)
            {
                return a + b;
            }
    
            public <#=T#> Subtract(<#=T#> a, <#=T#> b)
            {
                return a - b;
            }
        <#
            }
        #>
        }
    }
