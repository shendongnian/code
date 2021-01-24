     using System.Linq;
     ...
     string[] files = Directory.EnumerateFiles(DirPath, Dts.Variables["User::vCSV_Folder_File_Filter_1"].Value.ToString())
       .Concat(Directory.EnumerateFiles(DirPath, Dts.Variables["User::vCSV_Folder_File_Filter_2"].Value.ToString()))
       .Concat(Directory.EnumerateFiles(DirPath, Dts.Variables["User::vCSV_Folder_File_Filter_3"].Value.ToString()))
       .Concat(Directory.EnumerateFiles(DirPath, Dts.Variables["User::vCSV_Folder_File_Filter_4"].Value.ToString())) 
       .ToArray();
