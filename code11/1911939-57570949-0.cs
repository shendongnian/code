    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Collections.Generic;
    
    namespace SampleMultiSelectListExample.Models
    {
        //No touchy as per requirement
        public class UserAccess
        {
            //Assumption: This is your textarea
            public string BusinessJustification { get; set; }
            //This is user type id
            public int RequestAccessId { get; set; }
            //This is requested permission id
            public int AppPermissionId { get; set; }
            //This is application/business group which is a multi select
            public int ContainerId { get; set; }
            //public GroupType GroupType { get; set; }
            //rest of the columns in Table_Abc
        }
    
        //Make our class for our purpose. More of a viewmodel
        public partial class UserAccessData : UserAccess
        {
            //These two variables are to hold only one value as per  requirement
            public string requestAccessId { get; set; }
            public string appPermissionId { get; set; }
    
            public MultiSelectList RequestAccessIdList { get; set; }
            public MultiSelectList AppPermissionIdList { get; set; }
            public MultiSelectList ContainerIdList { get; set; }
    
            //Define multiselect list to capture multiple application/business role
            public List<string> containerIds { get; set; }
    
            //Define our constructor to get these values
            public UserAccessData()
            {
                this.RequestAccessIdList = GetRequestAccessIdList(null);
                this.AppPermissionIdList = GetAppPermissionIdList(null);
                this.ContainerIdList = GetContainerIdList(null);
            }
    
            public MultiSelectList GetRequestAccessIdList(string[] selectedValues)
            {
                List<Common> getRequestAccessList = new List<Common>()
                {
                    new Common() { ID = 1, Name= "User 1" },
                    new Common() { ID = 2, Name= "User 2" },
                    new Common() { ID = 3, Name= "User 3" },
                    new Common() { ID = 4, Name= "User 4" },
                    new Common() { ID = 5, Name= "User 5" },
                    new Common() { ID = 6, Name= "User 6" },
                    new Common() { ID = 7, Name= "User 7" }
                };
    
                return new MultiSelectList(getRequestAccessList, "ID", "Name", selectedValues);
            }
    
            public MultiSelectList GetAppPermissionIdList(string[] selectedValues)
            {
                List<Common> getAppPermissionList = new List<Common>()
                {
                    new Common() { ID = 1, Name= "User 1" },
                    new Common() { ID = 2, Name= "User 2" },
                    new Common() { ID = 3, Name= "User 3" },
                    new Common() { ID = 4, Name= "User 4" },
                    new Common() { ID = 5, Name= "User 5" }
                };
    
                return new MultiSelectList(getAppPermissionList, "ID", "Name", selectedValues);
            }
    
            //This will multi selectable as per our view
            public MultiSelectList GetContainerIdList(string[] selectedValues)
            {
                List<Common> getContainerList = new List<Common>()
                {
                    new Common() { ID = 1, Name= "User 1" },
                    new Common() { ID = 2, Name= "User 2" },
                    new Common() { ID = 3, Name= "User 3" }
                };
    
                return new MultiSelectList(getContainerList, "ID", "Name", selectedValues);
            }
        }
    
    
        //Generic class to match what a select list or dropdown list or combobox or radio box requires
        public class Common
        {
            public int ID { get; set; }
            public string Name { get; set; }
        }
    }
