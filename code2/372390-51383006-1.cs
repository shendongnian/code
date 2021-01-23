    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    
    namespace Example
    {
        public sealed class MsBuilder
        {
            public string ProjectPath { get; }
            public string LogPath { get; set; }
    
            public string Configuration { get; }
            public string Platform { get; }
    
            public int MaxCpuCount { get; set; } = 1;
            public string Target { get; set; } = "Build";
    
            public string MsBuildPath { get; set; } =
                @"C:\Program Files (x86)\Microsoft Visual Studio\2017\Enterprise\MSBuild\15.0\Bin\MsBuild.exe";
    
            public string BuildOutput { get; private set; }
    
            public MsBuilder(string projectPath, string configuration, string platform)
            {
                ProjectPath = !string.IsNullOrWhiteSpace(projectPath) ? projectPath : throw new ArgumentNullException(nameof(projectPath));
                if (!File.Exists(ProjectPath)) throw new FileNotFoundException(projectPath);
                Configuration = !string.IsNullOrWhiteSpace(configuration) ? configuration : throw new ArgumentNullException(nameof(configuration));
                Platform = !string.IsNullOrWhiteSpace(platform) ? platform : throw new ArgumentNullException(nameof(platform));
                LogPath = Path.Combine(Path.GetDirectoryName(ProjectPath), $"{Path.GetFileName(ProjectPath)}.{Configuration}-{Platform}.msbuild.log");
            }
    
            public bool Build(out string buildOutput)
            {
                List<string> arguments = new List<string>()
                {
                    $"/nologo",
                    $"\"{ProjectPath}\"",
                    $"/p:Configuration={Configuration}",
                    $"/p:Platform={Platform}",
                    $"/t:{Target}",
                    $"/maxcpucount:{(MaxCpuCount > 0 ? MaxCpuCount : 1)}",
                    $"/fileLoggerParameters:LogFile=\"{LogPath}\";Append;Verbosity=diagnostic;Encoding=UTF-8",
                };
    
                using (CommandLineProcess cmd = new CommandLineProcess(MsBuildPath, string.Join(" ", arguments)))
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine($"Build started: Project: '{ProjectPath}', Configuration: {Configuration}, Platform: {Platform}");
    
                    // Call MsBuild:
                    int exitCode = cmd.Run(out string processOutput, out string processError);
    
                    // Check result:
                    sb.AppendLine(processOutput);
                    if (exitCode == 0)
                    {
                        sb.AppendLine("Build completed successfully!");
                        buildOutput = sb.ToString();
                        return true;
                    }
                    else
                    {
                        if (!string.IsNullOrWhiteSpace(processError))
                            sb.AppendLine($"MSBUILD PROCESS ERROR: {processError}");
                        sb.AppendLine("Build failed!");
                        buildOutput = sb.ToString();
                        return false;
                    }
                }
            }
    
        }
    }
