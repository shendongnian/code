    public static NewExpression GetBodyExp(string field1, string field2, ParameterExpression Parametro)
            {    
                // SE OBTIENE LOS NOMBRES DE LOS TIPOS DE VARIABLE 
                string TypeName1 = Expression.Property(Parametro, field1).Type.Name;
                string TypeName2 = Expression.Property(Parametro, field2).Type.Name;
    
                // SE DECLARA EL TIPO ANONIMO SEGUN LOS TIPOS DE VARIABLES
                Type TypeAnonymous = null;
                if (TypeName1 == "String")
                {
                    string var1 = "0";
                    if (TypeName2 == "Int32")
                    {
                        int var2 = 0;
                        var example = new { var1, var2 };
                        TypeAnonymous = example.GetType();
                    }
    
                    if (TypeName2 == "String")
                    {
                        string var2 = "0";
                        var example = new { var1, var2 };
                        TypeAnonymous = example.GetType();
                    }    
                }    
    
                if (TypeName1 == "Int32")
                {
                    int var1 = 0;
                    if (TypeName2 == "Int32")
                    {
                        string var2 = "0";
                        var example = new { var1, var2 };
                        TypeAnonymous = example.GetType();
                    }
    
                    if (TypeName2 == "String")
                    {
                        string var2 = "0";
                        var example = new { var1, var2 };
                        TypeAnonymous = example.GetType();
                    }    
                }
                
                //se declaran los TIPOS NECESARIOS PARA GENERAR EL BODY DE LA EXPRESION LAMBDA
                MemberExpression[] args = new[] { Expression.PropertyOrField(Parametro, field1), Expression.PropertyOrField(Parametro, field2) };
                ConstructorInfo CInfo = TypeAnonymous.GetConstructors()[0];
                IEnumerable<MemberInfo> a = TypeAnonymous.GetMembers().Where(m => m.MemberType == MemberTypes.Property);
    
                //BODY 
                NewExpression body = Expression.New(CInfo, args, TypeAnonymous.GetMembers().Where(m => m.MemberType == MemberTypes.Property));
                
                return body;
            }
