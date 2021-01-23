     [BuildActivity(HostEnvironmentOption.All)]
    public sealed class UpdateWebConfigWithBuild : CodeActivity {
        
        // Define the activity arguments of type string
        [RequiredArgument]
        public InArgument<IBuildDetail> BuildDetail { get; set; }
        
        // The SourcesDirectory as initialized in the Build Process Template
        [RequiredArgument]
        public InArgument<string> SourcesDirectory { get; set; }
        // The SourcesDirectory as initialized in the Build Process Template
        [RequiredArgument]
        public InArgument<string> TFSBuildNumberAppSettingName { get; set; }
        public OutArgument<string> TextOut { get; set; }
        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.
        protected override void Execute(CodeActivityContext context) {
            // Obtain the runtime value of the Text input argument
            // Contains the build number
            IBuildDetail buildDetail = context.GetValue(this.BuildDetail);
            // The TFS directoty
            string sourcesDirectory = context.GetValue(this.SourcesDirectory);
            // web config app setting
            string TFSBuildNumberSetting = context.GetValue(this.TFSBuildNumberAppSettingName);
            // output String
            string output = String.Empty;
           
             // Get all AssemblyInfo files
            foreach (string file in Directory.EnumerateFiles(sourcesDirectory,"web.config", SearchOption.AllDirectories)) {
                 // IS tag founds
                bool settingFound = false;
                FileAttributes attributes = File.GetAttributes(file);
                // Remove readonly attribute
                if ((attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly) {
                    //Remove readonly
                    File.SetAttributes(file,attributes^FileAttributes.ReadOnly);
                }
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(file);
                // iterate through all the app settings to find the TFS BUILD 
                foreach (XmlNode node in xmlDoc.SelectNodes("/configuration/appSettings/add")) {
                    // MATCH
                    if (node.Attributes.GetNamedItem("key") != null && node.Attributes.GetNamedItem("value") != null && node.Attributes.GetNamedItem("key").Value.Equals("TFSBuildNumber")) {
                        node.Attributes.GetNamedItem("value").Value = buildDetail.BuildNumber;
                        settingFound = true;
                        output += "MODIFIED with BuildNumber " + buildDetail.BuildNumber.ToString() + " :" + file + "\n";
                        break;
                    }
                }
                // if the app setting is not found then add it
                if (!settingFound) {
                    XmlNode node = xmlDoc.SelectSingleNode("/configuration/appSettings");
                    if (null != node) {
                        XmlElement elem = xmlDoc.CreateElement("add");
                        XmlAttribute attrKey = xmlDoc.CreateAttribute("key");
                        attrKey.Value = "TFSBuildNumber";
                        XmlAttribute attrVal = xmlDoc.CreateAttribute("value");
                        attrVal.Value = buildDetail.BuildNumber;
                        elem.Attributes.Append(attrKey);
                        elem.Attributes.Append(attrVal);
                        node.AppendChild(elem);
                        output += "ADDED with BuildNumber " + buildDetail.BuildNumber.ToString() + " :" + file + "\n";
                    }
                }
                // Save file
                xmlDoc.Save(file);
                //add readonly attribute back to web.config file
                File.SetAttributes(file,attributes | FileAttributes.ReadOnly);
            }
            // Set the values
            context.SetValue<string>(this.TextOut,output);
        }
