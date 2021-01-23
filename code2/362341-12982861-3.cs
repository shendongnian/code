    <UsingTask TaskName="MyCustomTask" TaskFactory="CodeTaskFactory" AssemblyFile="$(MSBuildToolsPath)\Microsoft.Build.Tasks.v4.0.dll">
        <ParameterGroup>
            <SomeStrings ParameterType="Microsoft.Build.Framework.ITaskItem[]" Required="true" />
        </ParameterGroup>
        <Task>
            <Code Type="Class" Language="cs"><![CDATA[
                using System;
                using Microsoft.Build.Framework;
                using Microsoft.Build.Utilities;
                public class MyCustomTask : Task
                {  
                    public ITaskItem[] SomeStrings { get; set; }
                    
                    public override bool Execute()
                    {
                        foreach (var item in SomeStrings)
                        {
                            Log.LogMessage(MessageImportance.High, 
                                           "Got item {0}",
                                           item.ItemSpec);
                            Log.LogMessage(" -> {0} -> {1}", 
                                           item.GetMetadata("Comparison"),
                                           item.GetMetadata("MoreDetail"));
                        }
                        return true;
                    }
                }
            ]]></Code>
        </Task>
    </UsingTask>
