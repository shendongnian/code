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
                            Console.WriteLine("Got " + item.ItemSpec);
                            Console.WriteLine(" -> " + item.GetMetadata("Comparison"));
                        }
                        return true;
                    }
                }
            </Code>
        </Task>
    </UsingTask>
