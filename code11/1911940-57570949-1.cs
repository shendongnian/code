    using System;
    using Microsoft.AspNetCore.Mvc;
    using SampleMultiSelectListExample.Models;
    
    namespace SampleMultiSelectListExample.Controllers
    {
        public class HomeController : Controller
        {
            public IActionResult Index()
            {
                //Here we get our items as required
                //UserAccessData useraccessdata = new UserAccessData();
                //If you are getting your data from a db, you can do something like this
                //useraccessdata.ContainerIdList = GetAllContainerId(null);
                //useraccessdata.RequestAccessIdList = GetAllRequestAccessId(null);
                //useraccessdata.AppPermissionIdList= GetAllAppPermissionIdList(null);
    
                //Now since I am hardcoding these values, I can directly send my model to the view to render
    
                return View(new UserAccessData());
            }
    
            //Just an example implementation of how this would look via a webservice:
            //private MultiSelectList GetAllContainerId(string[] selectedValues)
            //{
            //    //Just an example using HttpClient to call a webservice to get this data.
            //    var client = clientFactory.CreateClient(baseAPIUrl);
            //    var containerIdDTO = httpClient.GetAsync<UserDtoList>(new Uri(new Uri(baseAPIUrl), $"Master/getUserDto").AbsoluteUri).Result;
            //    //return containerIdDTO.data;
            //    List<Common> allContainerIds = new List<Common>();
            //    foreach (var item in containerIdDTO)
            //    {
            //        Common common = new Common();
            //        common.ID = item.id;
            //        common.Name = item.fullName;
            //        allContainerIds.Add(common);
            //    }
    
            //    return new MultiSelectList(allContainerIds, "ID", "Name", selectedValues);
            //}
    
            //Now process your selected data as required
            [HttpPost]
            [ValidateAntiForgeryToken]
            public IActionResult ProcessInformation(UserAccessData useraccessdata)
            {
                //Our main model which is untouched
                UserAccess user = new UserAccess();
                user.AppPermissionId = Convert.ToInt32(useraccessdata.appPermissionId);
                user.RequestAccessId = Convert.ToInt32(useraccessdata.requestAccessId);
                user.BusinessJustification = useraccessdata.BusinessJustification;
    
                //Now for every container list, do your processing
                foreach(var containerid in useraccessdata.containerIds)
                {
                    //Insert in your DB here 
                    //var insert = CallDBInsert(user);
                }
                return View();
            }
        }
    }
