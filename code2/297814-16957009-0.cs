    var codeBase = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
                        codeBase = codeBase.Substring(8); //Remove the "file:///" prefix in front of the actual path.
    
    var dir = codeBase.Substring(0, codeBase.LastIndexOf("/", System.StringComparison.Ordinal) + 1); //Cut out the dll file name.
                        
    var file = @"ErrorMessages.xml";
    
    var targetPath = dir + file;
