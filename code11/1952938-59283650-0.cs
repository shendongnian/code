        Handlebars.RegisterHelper(Equals, (output, options, context, data) => 
                    {
                        if (data.Length != 2)
                            options.Inverse(output, null);
        
                        if (data[0].Equals(data[1]))
                            options.Template(output, null);
                        else
                            options.Inverse(output, null);
                    });
                    Handlebars.RegisterHelper(LowerThan, (output, options, context, data) =>
                    {
                        IntegerOperation(LowerThan, ref output, ref options, ref data);
                    });
        
                    Handlebars.RegisterHelper(GreaterThan, (output, options, context, data) =>
                    {
                        IntegerOperation(GreaterThan, ref output, ref options, ref data);
                    });
        
                    Handlebars.RegisterHelper(LowerEquals, (output, options, context, data) =>
                    {
                        IntegerOperation(LowerEquals, ref output, ref options, ref data);
                    });
        
                    Handlebars.RegisterHelper(GreaterEquals, (output, options, context, data) =>
                    {
                        IntegerOperation(GreaterEquals, ref output, ref options, ref data);
                    });
            private static void IntegerOperation(string operation, ref System.IO.TextWriter output, ref HelperOptions options, ref object[] data)
            {
                if (data.Length != 2)
                {
                    options.Inverse(output, null);
                    return;
                }
    
                if (!int.TryParse(data[0].ToString(), out int leftValue))
                {
                    options.Inverse(output, null);
                    return;
                }
    
                if (!int.TryParse(data[1].ToString(), out int rightValue))
                {
                    options.Inverse(output, null);
                    return;
                }
    
                switch (operation)
                {
                    case "lt":
                        if (leftValue < rightValue)
                            options.Template(output, null);
                        else
                            options.Inverse(output, null);
                        break;
                    case "le":
                        if (leftValue <= rightValue)
                            options.Template(output, null);
                        else
                            options.Inverse(output, null);
                        break;
                    case "gt":
                        if (leftValue > rightValue)
                            options.Template(output, null);
                        else
                            options.Inverse(output, null);
                        break;
                    case "ge":
                        if (leftValue >= rightValue)
                            options.Template(output, null);
                        else
                            options.Inverse(output, null);
                        break;
                    default:
                        break;
                }
