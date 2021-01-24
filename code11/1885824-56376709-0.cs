    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;
  
    namespace AMU.AutoCAD.Update
    {
      public class AutoCadPluginInstaller
      {
        private static readonly Regex AutoloadFilenameRegex = new Regex("acad([\\d])*.lsp");
    
        public void Install(IEnumerable<string> pluginFiles)
        {
          var acadDirs = this.GetAcadInstallationPaths();
          var autoloadFiles = acadDirs.Select(this.GetAutoloadFile);
    
          foreach (var autoloadFile in autoloadFiles)
            this.InstallIntoAutoloadFile(autoloadFile, pluginFiles);
        }
    
        private void InstallIntoAutoloadFile(string autoloadFile, IEnumerable<string> pluginFiles)
        {
          try
          {
            var content = File.ReadAllLines(autoloadFile).ToList();
            foreach (var pluginFile in pluginFiles)
            {
              var loadLine = this.BuildLoadLine(pluginFile);
              if(!content.Contains(loadLine))
                content.Add(loadLine);
            }
    
            File.WriteAllLines(autoloadFile, content);
          }
          catch (Exception ex)
          {
            //log.Log();
          }
        }
    
        private string BuildLoadLine(string pluginFile)
        {
          pluginFile = pluginFile.Replace(@"\", "/");
          return $"(command \"_netload\" \"{pluginFile}\")";
        }
    
        private IEnumerable<string> GetAcadInstallationPaths()
        {
          var programDirs =
            Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
    
          var autoDeskDir = Path.Combine(programDirs, "Autodesk");
          if (!Directory.Exists(autoDeskDir))
            return null;
    
          return Directory.EnumerateDirectories(autoDeskDir)
                                 .Where(d => d.Contains("AutoCAD"));
        }
    
        private string GetAutoloadFile(string acadDir)
        {
          var supportDir = Path.Combine(acadDir, "Support");
          var supportFiles = Directory.EnumerateFiles(supportDir);
          return supportFiles.FirstOrDefault(this.IsSupportFile);
        }
    
        private bool IsSupportFile(string path)
          => AutoloadFilenameRegex.IsMatch(Path.GetFileName(path));
      }
    }
