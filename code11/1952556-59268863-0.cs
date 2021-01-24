                Handlebars.RegisterHelper(DateFormat, (output, context, data) => 
                {
                    DateTime.TryParse(data[0].ToString(), out DateTime date);
    
                    var dictionary = data[1] as HandlebarsDotNet.Compiler.HashParameterDictionary;
                    var formatString = dictionary["formatString"];
    
                    output.WriteSafeString(date.ToString(formatString.ToString()));
                });
