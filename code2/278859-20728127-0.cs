    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
        namespace MusicMuttPrototype
        {
            public class clsShellFileInfo
            {
                public Exception errorException;
                public enum FileDetailInfo
                {
                    Name = 0,
                    Year = 15,
                    Size = 1,
                    Track_Number = 19,
                    Type = 2,
                    Genre = 20,
                    Date_Modified = 3,
                    Duration = 27,
                    Date_Created = 4,
                    Bit_Rate = 28,
                    Date_Accessed = 5,
                    Protected = 23,
                    Attributes = 6,
                    Camera_Model = 24,
                    Status = 7,
                    Date_Picture_Taken = 25,
                    Owner = 8,
                    Dimensions = 26,
                    Author = 9,
                    Not_used = 27,
                    Title = 10,
                    Not_used_file = 28,
                    Subject = 11,
                    //Not_used = 29,
                    Category = 12,
                    Company = 30,
                    Pages = 13,
                    Description = 31,
                    Comments = 14,
                    File_Version = 32,
                    Copyright = 15,
                    Product_Name_Chapter = 33,
                    //Scripting Quicktest Profess11ional Page 63 
                    Artist = 16,
                    Product_Version = 34,
                    Album_Title = 17,
                    Retrieves_the_info_tip_inf = -1
                }
        
                public string getFileDetails(string fileFolder, string filePath, FileDetailInfo infotype)
                {
                    string strReturnval = "";
                    try
                    {
                        Shell32.Shell fileshell = new Shell32.Shell();
                        Shell32.Folder fileshellfolder = fileshell.NameSpace(fileFolder);
                        Shell32.FolderItem Item = fileshellfolder.ParseName(filePath);
                        strReturnval = fileshellfolder.GetDetailsOf(Item, (int)infotype);
                    }
                    catch (Exception ex)
                    {
        
                        errorException = ex;
                    }
                    return strReturnval;
                }
        
        
            }
        }
